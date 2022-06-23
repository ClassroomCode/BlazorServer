using CarToolDemo.Core.Interfaces.Models;

namespace CarToolDemo.Core.Interfaces.Data;

public interface ICarsData
{
  Task<IEnumerable<ICar>> All();

  Task<ICar?> One(int carId);

  Task<ICar> Append(INewCar car);

  Task Remove(int carId);

  Task Replace(ICar car);
}