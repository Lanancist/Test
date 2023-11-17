#pragma once
namespace Ecology_Test_User {
	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	/// <summary>
	/// Сводка для MyForm
	/// </summary>
	public ref class MyForm : public System::Windows::Forms::Form
	{
	public:
		MyForm(void)
		{
			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
		}
	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~MyForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::TabControl^ tabs;


	private: System::Windows::Forms::CheckedListBox^ checkedListBox1;
	private: System::Windows::Forms::TextBox^ textBox1;
	private: System::Windows::Forms::TabPage^ tabPage1;

	private: System::Windows::Forms::CheckedListBox^ checkedListBox2;
	private:
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		System::ComponentModel::Container^ components;
#pragma region Windows Form Designer generated code
		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		void InitializeComponent(void)
		{
			System::ComponentModel::ComponentResourceManager^ resources = (gcnew System::ComponentModel::ComponentResourceManager(MyForm::typeid));
			this->tabs = (gcnew System::Windows::Forms::TabControl());
			this->SuspendLayout();
			// 
			// tabs
			// 
			this->tabs->Location = System::Drawing::Point(0, 0);
			this->tabs->Margin = System::Windows::Forms::Padding(4);
			this->tabs->Multiline = true;
			this->tabs->Name = L"tabs";
			this->tabs->SelectedIndex = 0;
			this->tabs->Size = System::Drawing::Size(965, 567);
			this->tabs->TabIndex = 0;
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(8, 16);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->AutoScroll = true;
			this->ClientSize = System::Drawing::Size(965, 567);
			this->Controls->Add(this->tabs);
			this->Icon = (cli::safe_cast<System::Drawing::Icon^>(resources->GetObject(L"$this.Icon")));
			this->Margin = System::Windows::Forms::Padding(4);
			this->Name = L"MyForm";
			this->Text = L"Тест по экологии";
			this->FormClosing += gcnew System::Windows::Forms::FormClosingEventHandler(this, &MyForm::MyForm_FormClosing);
			this->Load += gcnew System::EventHandler(this, &MyForm::MyForm_Load);
			this->SizeChanged += gcnew System::EventHandler(this, &MyForm::MyForm_SizeChanged);
			this->ResumeLayout(false);

		}
		array<TabPage^>^ tabPages;
		int n = 5;
#pragma endregion
	private: System::Void MyForm_Load(System::Object^ sender, System::EventArgs^ e) {
		
		tabs->Top = 5;
		tabs->Left = 5;
		tabs->Width = this->Width - 26;
		tabs->Height = this->Height - tabs->Top-5;
		tabPages = gcnew array<TabPage^>(n);
		for (int i = 0; i < n; i++)
		{
			tabPages[i] = gcnew TabPage();
			tabPages[i]->Visible = 1;
			tabPages[i]->BackColor = Color::White;
			tabPages[i]->Text = "Вопрос " + (i + 1);
			tabPages[i]->AutoScroll = true;
			tabPages[i]->Location = System::Drawing::Point(4, 22);
			tabPages[i]->Padding = System::Windows::Forms::Padding(3);
			tabs->Controls->Add(tabPages[i]);
			SplitContainer^ splitter = gcnew SplitContainer();
			tabPages[i]->Controls->Add(splitter);
			splitter->Parent = tabPages[i];
			splitter->Name = "splitter1";
			splitter->Orientation = Orientation::Horizontal;
			splitter->SplitterDistance = 236;
			CheckedListBox^ answers = gcnew CheckedListBox();
			splitter->Panel2->Controls->Add(answers);
			answers->Parent = splitter->Panel2;
			splitter->Name = "Check1";
		}
	}
	private: System::Void MyForm_SizeChanged(System::Object^ sender, System::EventArgs^ e) {
		tabs->Top = 5;
		tabs->Left = 5;
		tabs->Width = this->Width - 26;
		tabs->Height = this->Height - tabs->Top - 5;
	}
	private: System::Void MyForm_FormClosing(System::Object^ sender, System::Windows::Forms::FormClosingEventArgs^ e) {

	}
	};
}
