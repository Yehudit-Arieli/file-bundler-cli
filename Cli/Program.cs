//א.Program.cs – ה"מרכזיה"
//זה הקוד שמפעיל את התוכנה. כל פעם שאת כותבת dotnet run, המחשב קורא את השורות האלו:

//זה הקובץ הראשון שנדלק. התפקיד שלו הוא רק להגיד לתוכנה אילו פקודות קיימות.

//הוא יוצר rootCommand (הפקודה הראשית).

//הוא מוסיף לה שתי פקודות משנה: bundle(לאיחוד) ו - create - rsp(ליצירת קיצור דרך).
using System.CommandLine;
using Cli;

var rootCommand = new RootCommand("Root command for File Bundler CLI");

// הוספת פקודת ה-bundle
rootCommand.AddCommand(CommandHandler.CreateBundleCommand());

// הוספת פקודת ה-create-rsp
rootCommand.AddCommand(CommandHandler.CreateRspCommand());

await rootCommand.InvokeAsync(args);