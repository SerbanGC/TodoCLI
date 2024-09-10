using System.Text;

Db db = new Db();
TaskService service = new TaskService(db.FileLocation);
Meniu meniu = new Meniu(service, db);

meniu.OpenMeniu();