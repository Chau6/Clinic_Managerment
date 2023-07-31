using Semester_3_API_Personal.Models;

namespace Semester_3_API_Personal.Service;

public interface ManufacturerService
{
    public dynamic findAll();
    public bool Create(Manufacturer manufacturer);
    public bool Edit(Manufacturer manufacturer);
    public bool Delete(int id);
    public dynamic find(int id);
}
