using UnitOFWorkPattern.Model;

namespace UnitOFWorkPattern.Interface
{
    public interface IToDoService
    {
        ToDo AddTask(ToDo todo);
        List<ToDo> GetAllTask();

        ToDo ToDoGetTaskById(int ID);
        ToDo UpdateTask(ToDo todo);

        bool DeleteTaskByID(int ID);

    }
}
