/***************************
* Michael Villar
* SGPG215
*
*In Class Assignment 1
****************************/

#include <Windows.h>
#include <d3d9.h>
#include <d3dx9math.h>
#include <time.h>
#include <stdio.h>

HINSTANCE hInst;
HWND wndHandle;
LPDIRECT3D9 pD3D;
LPDIRECT3DDEVICE9 pd3dDevice;
LPDIRECT3DVERTEXBUFFER9 vertexBuffer;

//Camera Variables
D3DXMATRIX	matView,			//the view matrix
matProj;			//the projection matrix
D3DXVECTOR3 cameraPosition,		//the position of camera
cameraLook;			//where the camera is pointing

//Custom Vertext Structure
struct CUSTOMVERTEX
{
	float x, y, z;
	DWORD color;
};


//Custom FVF, describes CUSTOMVERTEX
#define D3DFVF_CUSTOMVERTEX (D3DFVF_XYZ | D3DFVF_DIFFUSE)

// forward declarations
bool initWindow(HINSTANCE hInstance);
LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

bool initDirect3D(HWND hwnd);
void shutdownDirect3D();
bool createCube();

void createCamera(float nearClip, float farClip);
void placeCamera(D3DXVECTOR3 vec);
void pointCamera(D3DXVECTOR3 vec);

#define SCREEN_WIDTH 640
#define SCREEN_HEIGHT 480


//window event callback function
LRESULT CALLBACK WinProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch (message)
	{
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	}
	return DefWindowProc(hWnd, message, wParam, lParam);
}

bool CreateCube()
{

}

//entry point for a Windows program
int WINAPI WinMain(HINSTANCE hInstance,
	HINSTANCE hPrevInstance,
	LPSTR     lpCmdLine,
	int       nCmdShow)
{
	MSG msg;


	// register the class
	MyRegisterClass(hInstance);

	//set up the screen in windowed or fullscreen mode?
	DWORD style;
	if (FULLSCREEN)
		style = WS_EX_TOPMOST | WS_VISIBLE | WS_POPUP;
	else
		style = WS_OVERLAPPED;



	//was there an error creating the window?
	if (!initWindow(hInstance))
		return FALSE;

	if (!initDirect3D(wndHandle))
		return 0;

	//initialize the game
	if (!createCube())
		return 0;

	createCamera(1.0f, 500.0f);
	placeCamera(D3DXVECTOR3(0.0f, 0.0f, -450.0f));
	pointCamera(D3DXVECTOR3(0.0f, 0.0f, 0.0f));

	D3DXMATRIX meshMat, meshScale, meshRotate;
	//set rotation
	D3DXMatrixRotationY(&meshRotate, D3DXToRadian(45));
	//set scaling
	D3DXMatrixScaling(&meshScale, 1.0f, 1.0f, 1.0f);
	// multiply the scaling and rotation matrices to create the meshMat matrix
	D3DXMatrixMultiply(&meshMat, &meshScale, &meshRotate);

	//transform the object in world space
	pd3dDevice->SetTransform(D3DTS_WORLD, &meshMat);

	//Main Msg Loop
	ZeroMemory(&msg, sizeof(msg));
	while (msg.message != WM_QUIT)
	{
		// check for messages
		if (PeekMessage(&msg, NULL, 0U, 0U, PM_REMOVE))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
		else
		{
			pd3dDevice->Clear(0, NULL, D3DCLEAR_TARGET,
				D3DCOLOR_XRGB(255, 255, 255), 10.0F, 0);
			pd3dDevice->BeginScene();
			pd3dDevice->SetStreamSource(0, vertexBuffer, 0,
				sizeof(CUSTOMVERTEX));
			pd3dDevice->SetFVF(D3DFVF_CUSTOMVERTEX);

			pd3dDevice->DrawPrimitive(D3DPT_TRIANGLESTRIP, 0, 2);
			pd3dDevice->DrawPrimitive(D3DPT_TRIANGLESTRIP, 4, 2);
			pd3dDevice->DrawPrimitive(D3DPT_TRIANGLESTRIP, 8, 2);
			pd3dDevice->DrawPrimitive(D3DPT_TRIANGLESTRIP, 12, 2);
			pd3dDevice->DrawPrimitive(D3DPT_TRIANGLESTRIP, 16, 2);
			pd3dDevice->DrawPrimitive(D3DPT_TRIANGLESTRIP, 20, 2);

			pd3dDevice->EndScene();

			pd3dDevice->Present(NULL, NULL, NULL, NULL);
		}
	}

	shutdownDirect3D();
	return (int)msg.wParam;
}

//helper function to set up the window properties
bool initWindow(HINSTANCE hInstance)
{
	//create the window class structure
	WNDCLASSEX wcex;
	wcex.cbSize = sizeof(WNDCLASSEX);

	//fill the struct with info
	wcex.style = CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc = (WNDPROC)WinProc;
	wcex.cbClsExtra = 0;
	wcex.cbWndExtra = 0;
	wcex.hInstance = hInstance;
	wcex.hIcon = NULL;
	wcex.hCursor = LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
	wcex.lpszMenuName = NULL;
	wcex.lpszClassName = "DirectX Example";
	wcex.hIconSm = NULL;

	//set up the window with the class info
	return RegisterClassEx(&wcex);

	//create a new window
	wndHandle = CreateWindow(
		"DirectX Example",              //window class
		"DirectX Example",              //title bar
		WS_OVERLAPPEDWINDOW,                 //window style
		CW_USEDEFAULT,         //x position of window
		CW_USEDEFAULT,         //y position of window
		SCREEN_WIDTH,          //width of the window
		SCREEN_HEIGHT,         //height of the window
		NULL,                  //parent window
		NULL,                  //menu
		hInstance,             //application instance
		NULL);                 //window parameters

	if (!wndHandle)
		return false;
	ShowWindow(wndHandle, SW_SHOW);
	UpdateWindow(wndHandle);

	return true;
}

