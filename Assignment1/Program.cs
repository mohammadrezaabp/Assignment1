using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBaseContext dataBaseContext = new DataBaseContext();
            //uncomment next line for first build
            //AddMockData(dataBaseContext);
            var myEntity = GetEntity(dataBaseContext);
            RemoveEntity(dataBaseContext, myEntity);
            SetCurrentEntityStateToDetached(dataBaseContext, myEntity);
            UpdateEntityIsDeletedToTrue(dataBaseContext, myEntity);
            dataBaseContext.SaveChanges();
        }

        private static void UpdateEntityIsDeletedToTrue(DataBaseContext dataBaseContext, MyEntity myEntity)
        {
            myEntity.IsDeleted = true;
            dataBaseContext.Update(myEntity);
        }

        private static void SetCurrentEntityStateToDetached(DataBaseContext dataBaseContext, MyEntity myEntity)
        {
            dataBaseContext.Entry(myEntity).State = EntityState.Detached;
        }

        private static void AddMockData(DataBaseContext dataBaseContext)
        {
            var mockData = new MyEntity
            {
                Name = "testData"
            };
            dataBaseContext.Add(mockData);
            dataBaseContext.SaveChanges();
        }

        private static EntityEntry<MyEntity> RemoveEntity(DataBaseContext dataBaseContext, MyEntity myEntity)
        {
            return dataBaseContext.Remove(myEntity);
        }

        private static MyEntity GetEntity(DataBaseContext dataBaseContext)
        {
            return dataBaseContext.Find<MyEntity>(1);
        }
    }

}
