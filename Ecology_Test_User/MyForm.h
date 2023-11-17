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
	private: System::Windows::Forms::SplitContainer^ splitContainer1;
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
			this->checkedListBox1 = (gcnew System::Windows::Forms::CheckedListBox());
			this->textBox1 = (gcnew System::Windows::Forms::TextBox());
			this->splitContainer1 = (gcnew System::Windows::Forms::SplitContainer());
			this->tabPage1 = (gcnew System::Windows::Forms::TabPage());
			this->tabs->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->splitContainer1))->BeginInit();
			this->splitContainer1->SuspendLayout();
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
			// checkedListBox1
			// 
			this->checkedListBox1->Dock = System::Windows::Forms::DockStyle::Fill;
			this->checkedListBox1->FormattingEnabled = true;
			this->checkedListBox1->HorizontalScrollbar = true;
			this->checkedListBox1->Items->AddRange(gcnew cli::array< System::Object^  >(6) {
				L"Вариант 1", L"Вариант 2", L"Вариант 3",
					L"Вариант 4", L"Вариант 5", L"Вариант 6"
			});
			this->checkedListBox1->Location = System::Drawing::Point(0, 0);
			this->checkedListBox1->Name = L"checkedListBox1";
			this->checkedListBox1->Size = System::Drawing::Size(710, 189);
			this->checkedListBox1->TabIndex = 0;
			// 
			// textBox1
			// 
			this->textBox1->Dock = System::Windows::Forms::DockStyle::Fill;
			this->textBox1->Location = System::Drawing::Point(0, 0);
			this->textBox1->Multiline = true;
			this->textBox1->Name = L"textBox1";
			this->textBox1->ReadOnly = true;
			this->textBox1->ScrollBars = System::Windows::Forms::ScrollBars::Vertical;
			this->textBox1->ShortcutsEnabled = false;
			this->textBox1->Size = System::Drawing::Size(710, 236);
			this->textBox1->TabIndex = 1;
			// 
			// splitContainer1
			// 
			this->splitContainer1->Dock = System::Windows::Forms::DockStyle::Fill;
			this->splitContainer1->Location = System::Drawing::Point(3, 3);
			this->splitContainer1->Name = L"splitContainer1";
			this->splitContainer1->Orientation = System::Windows::Forms::Orientation::Horizontal;
			this->splitContainer1->Size = System::Drawing::Size(710, 429);
			this->splitContainer1->SplitterDistance = 236;
			this->splitContainer1->TabIndex = 2;
			// 
			// tabPage1
			// 
			this->tabPage1->AutoScroll = true;
			this->tabPage1->BackColor = System::Drawing::Color::White;
			this->tabPage1->Controls->Add(this->splitContainer1);
			this->tabPage1->Location = System::Drawing::Point(4, 22);
			this->tabPage1->Name = L"tabPage1";
			this->tabPage1->Padding = System::Windows::Forms::Padding(3);
			this->tabPage1->Size = System::Drawing::Size(716, 435);
			this->tabPage1->TabIndex = 2;
			this->tabPage1->Text = L"tabPage1";
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
			this->Text = L"Тест по экологии";
			this->FormClosing += gcnew System::Windows::Forms::FormClosingEventHandler(this, &MyForm::MyForm_FormClosing);
			this->Load += gcnew System::EventHandler(this, &MyForm::MyForm_Load);
			this->SizeChanged += gcnew System::EventHandler(this, &MyForm::MyForm_SizeChanged);
			this->tabs->ResumeLayout(false);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->splitContainer1))->EndInit();
			this->splitContainer1->ResumeLayout(false);
			this->tabPage1->ResumeLayout(false);
			this->ResumeLayout(false);

		}
		array<TabPage^>^ tabPages;
		int n = 5;
#pragma endregion
	private: System::Void MyForm_Load(System::Object^ sender, System::EventArgs^ e) {
		tabs->Height = this->Height - 49;
		tabs->Top = 5;
		tabs->Left = 5;
		tabs->Width = this->Width - 26;
		tabPages = gcnew array<TabPage^>(n);
		for (int i = 0; i < n; i++)
		{
			tabPages[i] = gcnew TabPage();
			tabPages[i]->Visible = 1;
			tabPages[i]->BackColor = Color::White;
			tabPages[i]->Text = "Вопрос" + (i + 1);
			tabPages[i]->AutoScroll = true;
			tabPages[i]->Controls->Add(this->splitContainer1);
			tabPages[i]->Location = System::Drawing::Point(4, 22);
			tabPages[i]->Padding = System::Windows::Forms::Padding(3);
			tabs->Controls->Add(tabPages[i]);
			SplitContainer^ splitter = gcnew SplitContainer();
			tabPages[i]->Container->Add(splitter);
			splitter->Name = "splitter1";
			splitter->Orientation = Orientation::Horizontal;
			splitter->SplitterDistance = 236;
			splitter->BackColor = Color::Red;
		}
	}
	private: System::Void MyForm_SizeChanged(System::Object^ sender, System::EventArgs^ e) {
		tabs->Height = this->Height - 49;
		tabs->Top = 5;
		tabs->Left = 5;
		tabs->Width = this->Width - 26;
	}
	private: System::Void MyForm_FormClosing(System::Object^ sender, System::Windows::Forms::FormClosingEventArgs^ e) {

	}
	};
}
