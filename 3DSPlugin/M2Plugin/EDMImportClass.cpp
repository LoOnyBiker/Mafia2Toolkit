#include "3dsmaxsdk_preinclude.h"
#include "EDMImportClass.h"
#include "M2EDM.h"
#include "MeshNormalSpec.h"

#define EDM_IMPORT_CLASS_ID	Class_ID(0xac9aa34b, 0xbb4578d1)

class EDMImportClassDesc : public ClassDesc2
{
public:
	virtual int IsPublic() { return TRUE; }
	virtual void* Create(BOOL /*loading = FALSE*/) { return new EDMImport(); }
	virtual const TCHAR *	ClassName() { return GetString(IDS_EDM_IMPORT_CLASS); }
	virtual SClass_ID SuperClassID() { return SCENE_IMPORT_CLASS_ID; }
	virtual Class_ID ClassID() { return EDM_IMPORT_CLASS_ID; }
	virtual const TCHAR* Category() { return GetString(IDS_CATEGORY); }

	virtual const TCHAR* InternalName() { return _T("M2Plugin"); }	// returns fixed parsable name (scripter-visible name)
	virtual HINSTANCE HInstance() { return hInstance; }					// returns owning module handle


};
ClassDesc2* GetEDMImportDesc() {
	static EDMImportClassDesc EDMImportDesc;
	return &EDMImportDesc;
}


INT_PTR CALLBACK M2PluginOptionsDlgProc(HWND hWnd, UINT message, WPARAM, LPARAM lParam) {
	static EDMImport* imp = nullptr;

	switch (message) {
	case WM_INITDIALOG:
		imp = (EDMImport *)lParam;
		CenterWindow(hWnd, GetParent(hWnd));
		return TRUE;

	case WM_CLOSE:
		EndDialog(hWnd, 0);
		return 1;
	}
	return 0;
}
static FILE *stream = NULL;
//EDM IMPORT SECTION
//=========================

EDMImport::EDMImport() {
}
EDMImport::~EDMImport() {
}
int EDMImport::ExtCount() {
	return 1;
}
const TCHAR* EDMImport::Ext(int n) {
	switch (n) {
	case 0:
		return _T("M2T");
	}
	return _T("");
}
const TCHAR* EDMImport::LongDesc() {
	return GetString(IDS_EDM_L_DESC);
}
const TCHAR* EDMImport::ShortDesc() {
	return GetString(IDS_EDM_S_DESC);
}
const TCHAR* EDMImport::AuthorName() {
	return GetString(IDS_AUTHOR);
}
const TCHAR* EDMImport::CopyrightMessage() {
	return _T("");
}
const TCHAR* EDMImport::OtherMessage1() {
	return _T("");
}
const TCHAR* EDMImport::OtherMessage2() {
	return _T("");
}
unsigned int EDMImport::Version() {
	return 1;
}
void EDMImport::ShowAbout(HWND hWnd) {}
int EDMImport::DoImport(const TCHAR* filename, ImpInterface* importerInt, Interface* ip, BOOL suppressPrompts)
{
	EDMWorkClass edm(filename, _T("rb"));
	stream = edm.Stream();

	//begin reading
	EDMStructure file = EDMStructure();
	file.ReadFromStream(stream);
	//set up parts and nodes
	std::vector<EDMPart> parts = file.GetParts();
	DummyObject* parentDummy = new DummyObject();
	INode* parent = ip->CreateObjectNode(parentDummy);
	parent->SetName(file.GetName().c_str());

	////lets goo.
	for (int i = 0; i != parts.size(); i++)
	{
		EDMPart part = parts[i];

		TriObject* triObject = CreateNewTriObject();
		Mesh &mesh = triObject->GetMesh();
		mesh = part.GetMesh();

		//texture stuff
		std::wstring path = _T("C:/Users/Connor/Desktop/textures/");

		MultiMtl *multiMat = NewDefaultMultiMtl();
		multiMat->SetNumSubMtls(file.GetParts()[0].GetMatNames().size());
		for (int x = 0; x != file.GetParts()[0].GetMatNames().size(); x++)
		{
			BitmapTex *texture = NewDefaultBitmapTex();
			path += file.GetParts()[0].GetMatNames()[x];
			texture->SetMapName(path.c_str());
			texture->SetName(file.GetParts()[0].GetMatNames()[x].c_str());

			Mtl* mtl; 
			mtl = multiMat->GetSubMtl(x);
			mtl->SetName(file.GetParts()[0].GetMatNames()[x].c_str());
			mtl->SetSubTexmap(1, texture);

			path = _T("C:/Users/Connor/Desktop/textures/");
		}

		//add to material library ONLY if it doesn't exist.
		ip->GetMaterialLibrary().Add(multiMat);

		INode* nPart = ip->CreateObjectNode(triObject);
		nPart->SetName(_T("Mesh"));
		nPart->SetMtl(multiMat);
		parent->AttachChild(nPart, 0);
	}

	Modifier *modifier = (Modifier*)ip->CreateInstance(OSM_CLASS_ID, Class_ID(M2_MODIFIER_CLASS_ID));
	modifier->GetParamBlockByID(0)->SetValue(1, 0, parts[0].GetHasNormals());
	modifier->GetParamBlockByID(0)->SetValue(2, 0, parts[0].GetHasTangents());
	modifier->GetParamBlockByID(0)->SetValue(3, 0, parts[0].GetHasUV0());
	GetCOREInterface12()->AddModifier(*parent, *modifier);
	importerInt->RedrawViews();


	////if(!suppressPrompts)
	////	DialogBoxParam(hInstance, 
	////			MAKEINTRESOURCE(IDD_PANEL), 
	////			GetActiveWindow(), 
	////			M2PluginOptionsDlgProc, (LPARAM)this);

	return TRUE;
}

