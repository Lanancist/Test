#include "MyForm.h"

using namespace System;
using namespace System::Windows::Forms;
[STAThreadAttribute]
int main(array<String^>^) {
   Application::SetCompatibleTextRenderingDefault(false);
   Application::EnableVisualStyles();
   Ecology_Test_User::MyForm form;
   Application::Run(% form);
}