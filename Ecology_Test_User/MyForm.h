#pragma once

namespace Ecology_Test_User {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// ������ ��� MyForm
	/// </summary>
	public ref class MyForm : public System::Windows::Forms::Form
	{
	public:
		MyForm(void)
		{
			InitializeComponent();
			//
			//TODO: �������� ��� ������������
			//
		}

	protected:
		/// <summary>
		/// ���������� ��� ������������ �������.
		/// </summary>
		~MyForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::TabControl^ tabs;
	protected:

	protected:

	private: System::Windows::Forms::TabPage^ tabPage1;
	private: System::Windows::Forms::CheckedListBox^ checkedListBox1;
	protected:



	private:
		/// <summary>
		/// ������������ ���������� ������������.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// ��������� ����� ��� ��������� ������������ � �� ��������� 
		/// ���������� ����� ������ � ������� ��������� ����.
		/// </summary>
		void InitializeComponent(void)
		{
			System::ComponentModel::ComponentResourceManager^ resources = (gcnew System::ComponentModel::ComponentResourceManager(MyForm::typeid));
			this->tabs = (gcnew System::Windows::Forms::TabControl());
			this->tabPage1 = (gcnew System::Windows::Forms::TabPage());
			this->checkedListBox1 = (gcnew System::Windows::Forms::CheckedListBox());
			this->tabs->SuspendLayout();
			this->tabPage1->SuspendLayout();
			this->SuspendLayout();
			// 
			// tabs
			// 
			this->tabs->Anchor = System::Windows::Forms::AnchorStyles::None;
			this->tabs->Controls->Add(this->tabPage1);
			this->tabs->Location = System::Drawing::Point(0, 0);
			this->tabs->Multiline = true;
			this->tabs->Name = L"tabs";
			this->tabs->SelectedIndex = 0;
			this->tabs->Size = System::Drawing::Size(724, 461);
			this->tabs->TabIndex = 0;
			// 
			// tabPage1
			// 
			this->tabPage1->AutoScroll = true;
			this->tabPage1->Controls->Add(this->checkedListBox1);
			this->tabPage1->Location = System::Drawing::Point(4, 22);
			this->tabPage1->Name = L"tabPage1";
			this->tabPage1->Padding = System::Windows::Forms::Padding(3);
			this->tabPage1->Size = System::Drawing::Size(716, 435);
			this->tabPage1->TabIndex = 2;
			this->tabPage1->Text = L"tabPage1";
			this->tabPage1->UseVisualStyleBackColor = true;
			// 
			// checkedListBox1
			// 
			this->checkedListBox1->FormattingEnabled = true;
			this->checkedListBox1->Items->AddRange(gcnew cli::array< System::Object^  >(3) { L"������� 1", L"������� 2", L"������� 3" });
			this->checkedListBox1->Location = System::Drawing::Point(46, 133);
			this->checkedListBox1->Name = L"checkedListBox1";
			this->checkedListBox1->Size = System::Drawing::Size(552, 244);
			this->checkedListBox1->TabIndex = 0;
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->AutoScroll = true;
			this->ClientSize = System::Drawing::Size(724, 461);
			this->Controls->Add(this->tabs);
			this->Icon = (cli::safe_cast<System::Drawing::Icon^>(resources->GetObject(L"$this.Icon")));
			this->Name = L"MyForm";
			this->Text = L"���� �� ��������";
			this->Load += gcnew System::EventHandler(this, &MyForm::MyForm_Load);
			this->SizeChanged += gcnew System::EventHandler(this, &MyForm::MyForm_SizeChanged);
			this->tabs->ResumeLayout(false);
			this->tabPage1->ResumeLayout(false);
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void MyForm_Load(System::Object^ sender, System::EventArgs^ e) {
		tabs->Height = this->Height - 49;
		tabs->Top= 5;
		tabs->Left = 5;
		tabs->Width = this->Width - 26;
	}
	
	private: System::Void MyForm_SizeChanged(System::Object^ sender, System::EventArgs^ e) {
		tabs->Height = this->Height - 49;
		tabs->Top = 5;
		tabs->Left = 5;
		tabs->Width = this->Width - 26;
	}
	};
}
