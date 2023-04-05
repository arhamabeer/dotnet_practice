namespace dotnet_mvc.Models
{
    public static class ModelBuilderExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   name = "Arham",
                   department = Dept.IT,
                   email = "arham@gmail.com",
                   id = 1,
               },
                 new Employee
                 {
                     name = "Abeer",
                     department = Dept.Design,
                     email = "arham@abeer.com",
                     id = 1,
                 },
                   new Employee
                   {
                       name = "Ahmed",
                       department = Dept.None,
                       email = "ahmed@aaa.com",
                       id = 1,
                   }
               );
        }
    }
}
