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
	private: System::Windows::Forms::TabPage^ tabPage2;
	private: System::Windows::Forms::SplitContainer^ splitContainer1;
	private: System::Windows::Forms::TextBox^ textBox2;
	private: System::Windows::Forms::CheckedListBox^ checkedListBox3;

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
			this->tabPage2 = (gcnew System::Windows::Forms::TabPage());
			this->splitContainer1 = (gcnew System::Windows::Forms::SplitContainer());
			this->textBox2 = (gcnew System::Windows::Forms::TextBox());
			this->checkedListBox3 = (gcnew System::Windows::Forms::CheckedListBox());
			this->tabs->SuspendLayout();
			this->tabPage2->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->splitContainer1))->BeginInit();
			this->splitContainer1->Panel1->SuspendLayout();
			this->splitContainer1->Panel2->SuspendLayout();
			this->splitContainer1->SuspendLayout();
			this->SuspendLayout();
			// 
			// tabs
			// 
			this->tabs->Controls->Add(this->tabPage2);
			this->tabs->Location = System::Drawing::Point(0, 0);
			this->tabs->Multiline = true;
			this->tabs->Name = L"tabs";
			this->tabs->SelectedIndex = 0;
			this->tabs->Size = System::Drawing::Size(724, 461);
			this->tabs->TabIndex = 0;
			// 
			// tabPage2
			// 
			this->tabPage2->Controls->Add(this->splitContainer1);
			this->tabPage2->Location = System::Drawing::Point(4, 22);
			this->tabPage2->Name = L"tabPage2";
			this->tabPage2->Padding = System::Windows::Forms::Padding(3);
			this->tabPage2->Size = System::Drawing::Size(716, 435);
			this->tabPage2->TabIndex = 0;
			this->tabPage2->Text = L"tabPage2";
			this->tabPage2->UseVisualStyleBackColor = true;
			// 
			// splitContainer1
			// 
			this->splitContainer1->Dock = System::Windows::Forms::DockStyle::Fill;
			this->splitContainer1->Location = System::Drawing::Point(3, 3);
			this->splitContainer1->Name = L"splitContainer1";
			this->splitContainer1->Orientation = System::Windows::Forms::Orientation::Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this->splitContainer1->Panel1->Controls->Add(this->textBox2);
			// 
			// splitContainer1.Panel2
			// 
			this->splitContainer1->Panel2->Controls->Add(this->checkedListBox3);
			this->splitContainer1->Size = System::Drawing::Size(710, 429);
			this->splitContainer1->SplitterDistance = 236;
			this->splitContainer1->TabIndex = 0;
			// 
			// textBox2
			// 
			this->textBox2->Dock = System::Windows::Forms::DockStyle::Fill;
			this->textBox2->Location = System::Drawing::Point(0, 0);
			this->textBox2->Multiline = true;
			this->textBox2->Name = L"textBox2";
			this->textBox2->ReadOnly = true;
			this->textBox2->ScrollBars = System::Windows::Forms::ScrollBars::Vertical;
			this->textBox2->ShortcutsEnabled = false;
			this->textBox2->Size = System::Drawing::Size(710, 236);
			this->textBox2->TabIndex = 0;
			// 
			// checkedListBox3
			// 
			this->checkedListBox3->Dock = System::Windows::Forms::DockStyle::Fill;
			this->checkedListBox3->FormattingEnabled = true;
			this->checkedListBox3->HorizontalScrollbar = true;
			this->checkedListBox3->Location = System::Drawing::Point(0, 0);
			this->checkedListBox3->Name = L"checkedListBox3";
			this->checkedListBox3->Size = System::Drawing::Size(710, 189);
			this->checkedListBox3->TabIndex = 0;
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
			this->Load += gcnew System::EventHandler(this, &MyForm::MyForm_Load);
			this->SizeChanged += gcnew System::EventHandler(this, &MyForm::MyForm_SizeChanged);
			this->tabs->ResumeLayout(false);
			this->tabPage2->ResumeLayout(false);
			this->splitContainer1->Panel1->ResumeLayout(false);
			this->splitContainer1->Panel1->PerformLayout();
			this->splitContainer1->Panel2->ResumeLayout(false);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->splitContainer1))->EndInit();
			this->splitContainer1->ResumeLayout(false);
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
			splitter->Name = "splitter"+i;
			splitter->Visible = true;
			splitter->Enabled = true;
			splitter->Dock = DockStyle::Fill;
			splitter->Orientation = Orientation::Horizontal;
			CheckedListBox^ answers = gcnew CheckedListBox();
			splitter->Panel2->Controls->Add(answers);
			answers->Parent = splitter->Panel2;
			splitter->Name = "Check"+i;
			answers->Dock = DockStyle::Fill;
			//splitter->SplitterDistance = 236;
			answers->BeginUpdate();
			for (int j = 0; j < 6; j++)
			{
				answers->Items->Add("Вариант" + (j+1), (j+1) % 2 == 1);
			}
			answers->EndUpdate();
			TextBox^ quest = gcnew TextBox();
			splitter->Panel2->Controls->Add(quest);
			quest->Parent = splitter->Panel2;
			splitter->Name = "Text" + i;
			splitter->Text = "Text" + i;
			quest->Dock = DockStyle::Fill;
			quest->Multiline = true;
			quest->ReadOnly = true;
			quest->ScrollBars = ScrollBars::Vertical;
			quest->ShortcutsEnabled = false;
			quest->TabIndex = 0;
		}
	}
	private: System::Void MyForm_SizeChanged(System::Object^ sender, System::EventArgs^ e) {
		tabs->Top = 5;
		tabs->Left = 5;
		tabs->Width = this->Width - 26;
		tabs->Height = this->Height - tabs->Top - 5;
	}
	/*private: System::Void MyForm_FormClosing(System::Object^ sender, System::Windows::Forms::FormClosingEventArgs^ e) {
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < this->tabPages[i]->Controls->Count; j++)
			{
				tabPages[i]->Controls->RemoveAt(j);
			}
		}
		
	}*/
};
}
