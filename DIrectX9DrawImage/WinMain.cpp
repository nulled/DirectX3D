#include <windows.h>
#include <d3dx9.h>

#pragma comment(lib, "d3dx9.lib") 
#pragma comment(lib, "d3d9.lib") 
#define Emsg(msg){MessageBox(NULL,msg,"Error",MB_OK|MB_ICONEXCLAMATION);} //macro for error pop-up

int WINDOW_WIDTH  = 1024; 
int WINDOW_HEIGHT = 768; 
bool windowed = true;

IDirect3D9       *pD3D; 
IDirect3DDevice9 *pDevice; 

LPDIRECT3DTEXTURE9 imagetex; //texture our image will be loaded into
LPD3DXSPRITE       sprite; //sprite to display our image
D3DXVECTOR3        imagepos; //vector for the position of the sprite

LRESULT CALLBACK wndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	switch (uMsg) 
	{
	case WM_CLOSE:
		PostQuitMessage(0);
		break;
	}
	return DefWindowProc(hWnd, uMsg, wParam, lParam);
}

HRESULT Initialize()
{
	if (FAILED(D3DXCreateTextureFromFile(pDevice, "test.png", &imagetex)))
	{
		Emsg("Failed to laod the image");
		return E_FAIL;
	}
	if (FAILED(D3DXCreateSprite(pDevice, &sprite)))
	{
		Emsg("Failed to create the sprite");
		return E_FAIL;
	}
	imagepos.x = 10.0f; 
	imagepos.y = 10.0f;
	imagepos.z = 0.0f;
	return S_OK;
}

void Render()
{
	pDevice->BeginScene();
	sprite->Begin(D3DXSPRITE_ALPHABLEND); // png uses alpha channel
	sprite->Draw(imagetex, NULL, NULL, &imagepos, 0xFFFFFFFF); // 0xFFFFFFFF for no color change
	sprite->End(); 
	pDevice->EndScene();
}

void CleanUp()
{
	if (pD3D)     pD3D->Release();
	if (pDevice)  pDevice->Release();
	if (sprite)   sprite->Release(); 
	if (imagetex) imagetex->Release();
}

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nShowCmd)
{
	WNDCLASSEX wc;
	wc.cbSize = sizeof(WNDCLASSEX);
	wc.style = CS_HREDRAW | CS_VREDRAW | CS_OWNDC;
	wc.lpfnWndProc = (WNDPROC)wndProc;
	wc.cbWndExtra = 0;
	wc.cbClsExtra = 0;
	wc.hInstance = hInstance;
	wc.hIcon = LoadIcon(NULL, IDI_WINLOGO);
	wc.hCursor = LoadCursor(NULL, IDC_ARROW);
	wc.hbrBackground = NULL;
	wc.lpszMenuName = NULL;
	wc.lpszClassName = "D3DTEST";
	wc.hIconSm = LoadIcon(NULL, IDI_WINLOGO);

	RECT rect;
	rect.top = (long)0;
	rect.left = (long)0;
	rect.right = WINDOW_WIDTH;
	rect.bottom = WINDOW_HEIGHT;

	RegisterClassEx(&wc);

	AdjustWindowRectEx(&rect, WS_OVERLAPPEDWINDOW, false, WS_EX_APPWINDOW | WS_EX_WINDOWEDGE);
	HWND hWindow = CreateWindowEx(NULL, "D3DTEST", "D3D TEST", WS_CLIPSIBLINGS | WS_CLIPCHILDREN | WS_OVERLAPPEDWINDOW, 0, 0, rect.right - rect.left, rect.bottom - rect.top, NULL, NULL, hInstance, NULL);

	ShowWindow(hWindow, SW_SHOW);
	UpdateWindow(hWindow);
	SetForegroundWindow(hWindow); //set our window on top
	SetFocus(hWindow);            //set the focus on our window

	D3DPRESENT_PARAMETERS d3dpp; //the presentation parameters that will be used when we will create the device
	ZeroMemory(&d3dpp, sizeof(d3dpp)); //to be sure d3dpp is empty
	d3dpp.Windowed = windowed; //use our global windowed variable to tell if the program is windowed or not
	d3dpp.hDeviceWindow = hWindow; //give the window handle of the window we created above
	d3dpp.BackBufferCount = 1; //set it to only use 1 backbuffer
	d3dpp.BackBufferWidth = WINDOW_WIDTH; //set the buffer to our window width
	d3dpp.BackBufferHeight = WINDOW_HEIGHT; //set the buffer to out window height
	d3dpp.BackBufferFormat = D3DFMT_X8R8G8B8; //the backbuffer format
	d3dpp.SwapEffect = D3DSWAPEFFECT_DISCARD; //SwapEffect

	pD3D = Direct3DCreate9(D3D_SDK_VERSION);

	if (FAILED(pD3D->CreateDevice(D3DADAPTER_DEFAULT, D3DDEVTYPE_HAL, hWindow, D3DCREATE_SOFTWARE_VERTEXPROCESSING, &d3dpp, &pDevice)))
	{
		Emsg("Failed to create device");
		CleanUp();
		return 1;
	}

	if (FAILED(Initialize()))
	{
		Emsg("Failed to initialize");
		CleanUp();
		return 1;
	}

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
			pDevice->Clear(0, 0, D3DCLEAR_TARGET, D3DCOLOR_XRGB(0, 0, 0), 1.0f, 0.0f);
			Render();
			pDevice->Present(NULL, NULL, NULL, NULL);
		}
	}

	CleanUp();
	return 0;
}