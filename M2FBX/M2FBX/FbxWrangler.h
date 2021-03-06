#ifndef FBX_WRANGER_HEADER
#define FBX_WRANGER_HEADER
#include <fbxsdk.h>
#include <iomanip>
#include <iostream>
#include "M2Model.h"

int ConvertM2T(const char* pSource, const char* pDest);
bool CreateDocument(FbxManager* pManager, FbxScene* pScene, ModelStructure model);
void CreateLightDocument(FbxManager* pManager, FbxDocument* pLightDocument);
FbxNode* CreatePlane(FbxManager* pManager, const char* pName, ModelStructure model);
FbxSurfacePhong* CreateMaterial(FbxManager* pManager, const char* pName);
FbxTexture*  CreateTexture(FbxManager* pManager, const char* pName);
FbxNode* CreateLight(FbxManager* pManager, FbxLight::EType pType);
#endif