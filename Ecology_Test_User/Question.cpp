#include <string>
class Question
{
private:
	int theme, status, answer, count;
	typedef	std::string INFO[7];
public:
	Question::Question(int t, int s, int a, int c, INFO& mass);
		~Question();

private:

};

Question::Question(int t, int s, int a, int c, INFO& mass)
{

}

Question::~Question()
{
}