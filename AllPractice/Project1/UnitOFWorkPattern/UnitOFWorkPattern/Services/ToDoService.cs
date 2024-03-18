using UnitOFWorkPattern.Context;
using UnitOFWorkPattern.Interface;
using UnitOFWorkPattern.Model;

namespace UnitOFWorkPattern.Services
{
    public class ToDoService : IToDoService
    {
        private readonly ToDoContext _context;

        public ToDoService(ToDoContext toDoContext)
        {
            this._context = toDoContext;
        }

        public ToDo AddTask(ToDo todo)
        {
            var result = _context.ToDo.Add(todo);
            _context.SaveChanges();
            return result.Entity;

        }

        public bool DeleteTaskByID(int ID)
        {
            var result = _context.ToDo.FirstOrDefault(t => t.Id == ID);
            if (result == null)
            {
                throw new Exception("Update the valid data");
            }
            try
            {
                _context.Remove(result);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ToDo> GetAllTask()
        {
            var result = _context.ToDo.ToList();
            return result;
        }

        public ToDo ToDoGetTaskById(int ID)
        {
            var result = _context.ToDo.FirstOrDefault(t => t.Id == ID);
            return result;
        }

        public ToDo UpdateTask(ToDo todo)
        {
            //var result = _context.ToDo.FirstOrDefault(t => t.Id == todo.Id);
            //if(result==null)
            //{
            //    throw new Exception("Update the valid data");
            //}
            //var UpdatedRecord =_context.Update(todo);
            //_context.SaveChanges();
            //return UpdatedRecord.Entity;


            var todoData = new ToDo
            {
                Id = todo.Id,
                Name = todo.Name,
                Description=todo.Description,
                Status = todo.Status,
                CreatedDt = todo.CreatedDt                
            };

            _context.ToDo.Update(todoData);
            _context.SaveChanges();
            return todo;
        }
    }
}
