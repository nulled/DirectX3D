#include <Windowsx.h>
#include <string>
#include <d3d9.h>
#include "Timer.h"
#include "Keyboard.h"

using namespace std;

IDirect3DDevice9* pDevice;
static KeyboardServer kServ;
POINT mousePos;

LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_DESTROY:
		PostQuitMessage(0);
		return 0;
	case WM_KEYDOWN:
		switch (wParam)
		{
		case VK_UP:
			kServ.OnUpPressed();
			break;
		case VK_DOWN:
			kServ.OnDownPressed();
			break;
		case VK_LEFT:
			kServ.OnLeftPressed();
			break;
		case VK_RIGHT:
			kServ.OnRightPressed();
			break;
		case VK_SPACE:
			kServ.OnSpacePressed();
			break;
		case VK_RETURN:
			kServ.OnEnterPressed();
			break;
		}
		break;
	case WM_KEYUP:
		switch (wParam)
		{
		case VK_UP:
			kServ.OnUpReleased();
			break;
		case VK_DOWN:
			kServ.OnDownReleased();
			break;
		case VK_LEFT:
			kServ.OnLeftReleased();
			break;
		case VK_RIGHT:
			kServ.OnRightReleased();
			break;
		case VK_SPACE:
			kServ.OnSpaceReleased();
			break;
		case VK_RETURN:
			kServ.OnEnterReleased();
			break;
		}
	case WM_LBUTTONDOWN:
	case WM_MBUTTONDOWN:
	case WM_RBUTTONDOWN:
	case WM_LBUTTONUP:
	case WM_MBUTTONUP:
	case WM_RBUTTONUP:
	case WM_MOUSEMOVE:
		// if ((wParam & MK_LBUTTON) != 0) // pressed the LEFT mouse button
		mousePos.x = GET_X_LPARAM(lParam);
		mousePos.y = GET_Y_LPARAM(lParam);
		return 0;
	}

	return DefWindowProc(hwnd, msg, wParam, lParam);
}

void PutPixel(int x, int y, int r, int g, int b)
{
	IDirect3DSurface9* pBackBuffer = NULL;
	D3DLOCKED_RECT rect;

	pDevice->GetBackBuffer(0, 0, D3DBACKBUFFER_TYPE_MONO, &pBackBuffer);
	pBackBuffer->LockRect(&rect, NULL, NULL);
	((D3DCOLOR*)rect.pBits)[x + (rect.Pitch >> 2) * y] = D3DCOLOR_XRGB(r, g, b);
	pBackBuffer->UnlockRect();
	pBackBuffer->Release();
}

struct Node
{
	int x, y, r, g, b;
	struct Node *next;
};

bool search(struct Node* head, int x, int y)
{
	while (head != NULL)
	{
		if (head->x == x && head->y == y)
			return true;

		head = head->next;
	}

	return false;
}

void push(struct Node** head_ref, int x, int y, int r, int g, int b)
{
	if (! search((*head_ref), x, y))
	{
		struct Node* new_node = new Node;

		new_node->x = x;
		new_node->y = y;
		new_node->r = r;
		new_node->g = g;
		new_node->b = b;

		/* link the old list to the new node */
		new_node->next = (*head_ref);

		/* move the head to point to the new node */
		(*head_ref) = new_node;
	}
}

void draw(struct Node* head)
{
	if (! head)
		return;

	// recursively traverse remaining nodes 
	draw(head->next);

	// work with data in struct
	PutPixel(head->x, head->y, head->r, head->g, head->b);
}

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE, PSTR, INT)
{
	// --------------------
	// Init Window
	// --------------------
	WNDCLASS wc;
	HWND hwnd;
	wc.style = CS_HREDRAW | CS_VREDRAW;
	wc.lpfnWndProc = WndProc;
	wc.cbClsExtra = 0;
	wc.cbWndExtra = 0;
	wc.hInstance = hInstance;
	wc.hIcon = LoadIcon(0, IDI_APPLICATION);
	wc.hCursor = LoadCursor(0, IDC_ARROW);
	wc.hbrBackground = (HBRUSH)GetStockObject(NULL_BRUSH);
	wc.lpszMenuName = 0;
	wc.lpszClassName = L"MainWnd";
	RegisterClass(&wc);
	RECT R = { 0, 0, 800, 600 };
	AdjustWindowRect(&R, WS_OVERLAPPEDWINDOW, false);
	int width = R.right - R.left;
	int height = R.bottom - R.top;
	hwnd = CreateWindow(L"MainWnd", L"DirectX", WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, width, height, 0, 0, hInstance, 0);
	ShowWindow(hwnd, SW_SHOW);
	UpdateWindow(hwnd);

	// --------------------
	// Init Direct X
	// --------------------
	IDirect3D9*	pDirect3D = Direct3DCreate9(D3D_SDK_VERSION);;
	D3DPRESENT_PARAMETERS d3dpp;
	ZeroMemory(&d3dpp, sizeof(d3dpp));
	d3dpp.Windowed = TRUE;
	d3dpp.SwapEffect = D3DSWAPEFFECT_DISCARD;
	d3dpp.BackBufferFormat = D3DFMT_UNKNOWN;
	d3dpp.PresentationInterval = D3DPRESENT_INTERVAL_ONE;
	d3dpp.Flags = D3DPRESENTFLAG_LOCKABLE_BACKBUFFER;
	pDirect3D->CreateDevice(D3DADAPTER_DEFAULT, D3DDEVTYPE_HAL, hwnd, D3DCREATE_HARDWARE_VERTEXPROCESSING | D3DCREATE_PUREDEVICE, &d3dpp, &pDevice);

	Timer timer;
	wstring titleStr;
	struct Node* head = NULL;

	timer.StartWatch();

	MSG msg;
	ZeroMemory(&msg, sizeof(msg));
	while (msg.message != WM_QUIT)
	{
		if (PeekMessage(&msg, NULL, 0, 0, PM_REMOVE))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
		else
		{
			// ---------
			// game code
			// ---------
			titleStr = to_wstring(timer.GetTimeMilli());

			pDevice->Clear(0, NULL, D3DCLEAR_TARGET, D3DCOLOR_XRGB(0, 0, 0), 0.0f, 0);

			titleStr = titleStr + L" Mouse: " + to_wstring(mousePos.x) + L"," + to_wstring(mousePos.y);

			SetWindowText(hwnd, titleStr.c_str());

			draw(head);

			PutPixel(mousePos.x, mousePos.y, 255, 255, 255);

			push(&head, (int)mousePos.x, (int)mousePos.y, 255, 255, 255);

			pDevice->Present(NULL, NULL, NULL, NULL);
		}
	}

	UnregisterClass(wc.lpszClassName, wc.hInstance);

	return 0;
}