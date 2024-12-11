using Lesson_2.Models;
using Lesson_2.Services;

namespace Lesson_2;

public class Program
{
    private static string studentUserName = "student";
    private static string studentPassword = "student";

    private static string teacherUserName = "teacher";
    private static string teacherPassword = "teacher";

    private static string directorUserName = "director";
    private static string directorPassword = "director";
    static void Main(string[] args)
    {
        StartFrontEnd();
    }
    public static void StartFrontEnd()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("0 . Stop");
            Console.WriteLine("1 . Login");
            Console.Write("Enter : ");
            var option = int.Parse(Console.ReadLine());

            if (option == 0)
            {
                Console.WriteLine("Thanks");
                return;
            }
            else if (option == 1)
            {
                LoginPage();
            }
        }
    }
    public static void LoginPage()
    {
        while (true)
        {
            Console.Clear();
            Console.Write("Enter user name : ");
            var userName = Console.ReadLine();
            Console.Write("Enter password : ");
            var password = Console.ReadLine();

            if (userName == directorUserName
                && password == directorPassword)
            {
                RunDirector();
            }
            else if (userName == teacherUserName
                && password == teacherPassword)
            {
                RunTeacher();
            }
            else if (userName == studentUserName
                && password == studentPassword)
            {
                RunStudent();
            }
        }
    }
    public static void RunDirector()
    {
        var teacherService = new TeacherService();
        var studentService = new StudentService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("0. Quit");
            Console.WriteLine("1. Add teacher");
            Console.WriteLine("2. Delete teacher");
            Console.WriteLine("3. Show all teachers");
            Console.WriteLine("4. Get by id");
            Console.WriteLine("5. Update teacher");
            Console.WriteLine("6. Add student");
            Console.WriteLine("7. Delete student");
            Console.WriteLine("8. Update student");
            Console.WriteLine("9. Show all students");
            Console.Write("Enter : ");
            var option = int.Parse(Console.ReadLine());

            if (option == 0)
            {
                return;
            }
            else if (option == 1)
            {
                var teacher = new Teacher();
                Console.Write("Enter first name : ");
                teacher.FirstName = Console.ReadLine();

                Console.Write("Enter last name : ");
                teacher.LastName = Console.ReadLine();

                Console.Write("Enter age : ");
                teacher.Age = int.Parse(Console.ReadLine());

                Console.Write("Enter gender : ");
                teacher.Gender = Console.ReadLine();

                Console.Write("Enter Subject : ");
                teacher.Subject = Console.ReadLine();

                teacherService.AddTeacher(teacher);
                Console.WriteLine("Succsecfuly,teacher is added");
            }
            else if (option == 2)
            {
                Console.Write("Enter id : ");
                var id = Guid.Parse(Console.ReadLine());
                teacherService.DeleteTeacher(id);
                Console.WriteLine("Teacher is deleted");
            }
            else if (option == 3)
            {
                var teachers = teacherService.GetAllTeacher();
                foreach (var teacher in teachers)
                {
                    Console.WriteLine($"id : {teacher.Id}");
                    Console.WriteLine($"First name : {teacher.FirstName}");
                    Console.WriteLine($"Last name : {teacher.LastName}");
                    Console.WriteLine($"Age : {teacher.Age}");
                    Console.WriteLine($"Subject : {teacher.Subject}");
                    Console.WriteLine($"Gender : {teacher.Gender}");
                    Console.WriteLine();
                }
            }
            else if (option == 4)
            {
                Console.Write("Enter id : ");
                var id = Guid.Parse(Console.ReadLine());
                var teacher = teacherService.GetById(id);
                Console.WriteLine($"id : {teacher.Id}");
                Console.WriteLine($"First name : {teacher.FirstName}");
                Console.WriteLine($"Last name : {teacher.LastName}");
                Console.WriteLine($"Age : {teacher.Age}");
                Console.WriteLine($"Subject : {teacher.Subject}");
                Console.WriteLine($"Gender : {teacher.Gender}");
                Console.WriteLine();
            }
            else if (option == 5)
            {
                var teacher = new Teacher();

                Console.Write("Enter id : ");
                teacher.Id = Guid.Parse(Console.ReadLine());

                Console.Write("Enter first name : ");
                teacher.FirstName = Console.ReadLine();

                Console.Write("Enter last name : ");
                teacher.LastName = Console.ReadLine();

                Console.Write("Enter age : ");
                teacher.Age = int.Parse(Console.ReadLine());

                Console.Write("Enter subject : ");
                teacher.Subject = Console.ReadLine();

                Console.Write("Enter gender : ");
                teacher.Gender = Console.ReadLine();

                teacherService.UpdateTeacher(teacher);
                Console.WriteLine("Succsecfully, teacher is updated");
            }
            else if (option == 6)
            {
                var student = new Student();

                Console.Write("Enter first name : ");
                student.FirstName = Console.ReadLine();

                Console.Write("Enter last name : ");
                student.LastName = Console.ReadLine();

                Console.Write("Enter age : ");
                student.Age = int.Parse(Console.ReadLine());

                Console.Write("Enter degree : ");
                student.Degree = Console.ReadLine();

                Console.Write("Enter gender : ");
                student.Gender = Console.ReadLine();

                studentService.AddStudent(student);
                Console.WriteLine("Succesfully,student is added");
            }
            else if (option == 7)
            {
                Console.Write("Enter id : ");
                var id = Guid.Parse(Console.ReadLine());
                studentService.DeleteStudent(id);
                Console.WriteLine("Student is deleted");
            }
            else if (option == 8)
            {
                var student = new Student();

                Console.Write("Enter id : ");
                student.Id = Guid.Parse(Console.ReadLine());

                Console.Write("Enter first name : ");
                student.FirstName = Console.ReadLine();

                Console.Write("Enter last name : ");
                student.LastName = Console.ReadLine();

                Console.Write("Enter age : ");
                student.Age = int.Parse(Console.ReadLine());

                Console.Write("Enter degree : ");
                student.Degree = Console.ReadLine();

                studentService.UpdateStudent(student);
                Console.WriteLine("Succesfully,student is updated");
            }
            else if (option == 9)
            {
                var students = studentService.GetAllStudents();

                foreach (var student in students)
                {
                    Console.WriteLine($"id : {student.Id}");
                    Console.WriteLine($"First name : {student.FirstName}");
                    Console.WriteLine($"Last name : {student.LastName}");
                    Console.WriteLine($"Age : {student.Age}");
                    Console.WriteLine($"Degree : {student.Degree}");
                    Console.WriteLine($"Gender : {student.Gender}");
                    Console.WriteLine($"Result : {student.Results}");
                    Console.WriteLine();
                }
            }


            Console.ReadKey();
        }
    }
    public static void RunTeacher()
    {
        var studentService = new StudentService();
        var testService = new TestService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("0. Quit");
            Console.WriteLine("1. Add test");
            Console.WriteLine("2. Delete test");
            Console.WriteLine("3. Read tests");
            Console.WriteLine("4. Get by id");
            Console.WriteLine("5. Update test");
            Console.WriteLine("6. Get random test");
            Console.Write("Enter : ");
            var option = int.Parse(Console.ReadLine());

            if (option == 0)
            {
                return;
            }
            else if (option == 1)
            {
                var test = new Test();
                Console.Write("Question text : ");
                test.QuestionText = Console.ReadLine();

                Console.Write("A variant : ");
                test.AVariant = Console.ReadLine();

                Console.Write("B variant : ");
                test.BVariant = Console.ReadLine();

                Console.Write("C variant : ");
                test.CVariant = Console.ReadLine();

                Console.Write("Answer A/B/C : ");
                test.Answer = Console.ReadLine();

                testService.AddTest(test);
                Console.WriteLine("Test is added");
            }
            else if (option == 2)
            {
                Console.Write("Enter id : ");
                var id = Guid.Parse(Console.ReadLine());
                testService.DeleteTest(id);
                Console.WriteLine("Test is deleted");
            }
            else if (option == 3)
            {
                var tests = testService.GetAllTests();
                foreach (var test in tests)
                {
                    Console.WriteLine($"id : {test.Id}");
                    Console.WriteLine($"Question text : {test.QuestionText}");
                    Console.WriteLine($"A variant : {test.AVariant}");
                    Console.WriteLine($"B variant : {test.BVariant}");
                    Console.WriteLine($"C variant : {test.CVariant}");
                    Console.WriteLine($"Answer : {test.Answer}");
                    Console.WriteLine();
                }
            }
            else if (option == 4)
            {
                Console.Write("Enter id : ");
                var id = Guid.Parse(Console.ReadLine());
                var test = testService.GetById(id);
                Console.WriteLine($"id : {test.Id}");
                Console.WriteLine($"Question text : {test.QuestionText}");
                Console.WriteLine($"A variant : {test.AVariant}");
                Console.WriteLine($"B variant : {test.BVariant}");
                Console.WriteLine($"C variant : {test.CVariant}");
                Console.WriteLine($"Answer : {test.Answer}");
                Console.WriteLine();
            }
            else if (option == 5)
            {
                var test = new Test();

                Console.Write("Question id : ");
                test.Id = Guid.Parse(Console.ReadLine());

                Console.Write("Question text : ");
                test.QuestionText = Console.ReadLine();

                Console.Write("A variant : ");
                test.AVariant = Console.ReadLine();

                Console.Write("B variant : ");
                test.BVariant = Console.ReadLine();

                Console.Write("C variant : ");
                test.CVariant = Console.ReadLine();

                Console.Write("Answer A/B/C : ");
                test.Answer = Console.ReadLine();

                testService.UpdateTest(test);
                Console.WriteLine("Test is updated");
            }
            else if (option == 6)
            {
                Console.Write("Enter : ");
                var choice = int.Parse(Console.ReadLine());
                var tests = testService.GetRandomTests(choice);

                foreach (var test in tests)
                {
                    Console.WriteLine($"id : {test.Id}");
                    Console.WriteLine($"Question text : {test.QuestionText}");
                    Console.WriteLine($"A variant : {test.AVariant}");
                    Console.WriteLine($"B variant : {test.BVariant}");
                    Console.WriteLine($"C variant : {test.CVariant}");
                    Console.WriteLine($"Answer A/B/C : {test.Answer}");
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }

    }

    public static void RunStudent()
    {
        var teacherService = new TeacherService();
        var studentService = new StudentService();
        var testService = new TestService();
        Console.Write("Enter id : ");
        var id = Guid.Parse(Console.ReadLine());
        var student = studentService.GetById(id);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("0. Quit");
            Console.WriteLine("1. Start test ");
            Console.WriteLine("2. React to teacher");
            Console.Write("Enter : ");

            var option = int.Parse(Console.ReadLine());

            if (option == 0)
            {
                return;
            }

            else if (option == 1)
            {
                Console.Clear();
                Console.Write("How many tests do you want to do : ");

                var amount = int.Parse(Console.ReadLine());

                var tests = testService.GetRandomTests(amount);
                var correctAnswer = 0;
                foreach (var test in tests)
                {
                    Console.WriteLine(test.QuestionText);
                    Console.WriteLine($"A) {test.AVariant}");
                    Console.WriteLine($"B) {test.BVariant}");
                    Console.WriteLine($"C) {test.CVariant}");

                    Console.Write("Choose answer A/B/C : ");
                    var answer = Console.ReadLine();

                    if (test.Answer == answer)
                    {
                        correctAnswer++;
                        Console.WriteLine("Correct");
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect , correct answer is : {test.Answer}");
                    }
                }
                var result = correctAnswer * 100d / tests.Count;
                student.Results.Add(result);
                studentService.UpdateStudent(student);
                Console.WriteLine($"Final answer : {result}%");
                Console.ReadKey();
            }
            else if (option == 2)
            {
                var teachers = teacherService.GetAllTeacher();
                foreach (var teacher in teachers)
                {
                    Console.WriteLine($"First name : {teacher.FirstName}");
                    Console.WriteLine($"Last name : {teacher.LastName}");
                    Console.WriteLine($"Age : {teacher.Age}");
                    Console.WriteLine($"Gender : {teacher.Gender}");
                    Console.WriteLine($"Subject : {teacher.Subject}");
                    Console.WriteLine();
                    Console.WriteLine("0.Back");
                    Console.WriteLine("1.Like");
                    Console.WriteLine("2.Dislike");

                    Console.Write("Choose : ");

                    option = int.Parse(Console.ReadLine());

                    if (option == 0)
                    {
                        return;
                    }
                    else if (option == 1)
                    {
                        teacherService.AddLike(teacher.Id);
                        Console.WriteLine("Thanks");
                    }
                    else if (option == 2)
                    {
                        teacherService.AddDislike(teacher.Id);
                        Console.WriteLine("Thanks");
                    }
                }
            }
        }
    }
}
