using Microsoft.Data.SqlClient;
using Dapper;
using PraticasComDapper.PraticascomDapperNet7;

namespace PraticasComDapper.PraticasComDappernet7
{
    public class ComandosSql
    {
        private int ListCategories { get; set; }
        private int CreateCategory { get; set; }
        private int UpdateCategory { get; set; }
        private int DeleteCategory { get; set; }
        private int DeleteProcedure { get; set; }
        private int DoLike { get; set; }
        public ComandosSql(){}
        public ComandosSql(int listCategories, int createCategory, int updateCategory, int deleteCategory, int deleteProcedure, int doLike)
        {
            ListCategories = listCategories;
            CreateCategory = createCategory;
            UpdateCategory = updateCategory;
            DeleteCategory = deleteCategory;
            DeleteProcedure = deleteProcedure;
            DoLike = doLike;
        }      
       
        #region Listing all Categories
        public static void listCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("SELECT [ID], [TITLE], [ORDER] FROM [CATEGORY]");
            Console.WriteLine("\nListing Category");
            foreach (var items in categories)
            {
               Console.WriteLine("------------------------------------");             
               System.Console.WriteLine($"{items.Id} - {items.Title}");
            }
        }
        #endregion
        #region Creating One New Category Row
        public static void createCategory(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Notar.io";
            category.Url = "Backend";
            category.Description = "like,share,subscribe";
            category.Order = 8;
            category.Summary = "ina_Dev.io";
            category.Featured = false;

            var insertQuery = @"INSERT INTO [CATEGORY] VALUES(@Id,@Title,@Url,@Summary,@Order,@Description,@Featured)";
            var insertRows = connection.Execute(insertQuery, new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            }); 
            Console.WriteLine("\nCreating Category");
            Console.WriteLine("------------------------------------");    
            Console.WriteLine($"{category.Id}/{category.Title}/{category.Url}/{category.Summary}/");
            Console.WriteLine($"{category.Order}/{category.Description}/{category.Featured}");        
            Console.WriteLine($"\n{insertRows} data Inserted");   
        }
        #endregion
        #region Updating One Category Row
        public static void updateCategory(SqlConnection connection)
        {
            var updateQuery = @"UPDATE [CATEGORY] 
            SET [Title]=@title, [Url]=@url,[Summary]=@summary, [Order]=@order,
                [Description]=@description, [Featured]=@featured WHERE [Id]= @id ";
            var updateRows = connection.Execute(updateQuery, new
            {
                Id = ("a6519bfd-2f21-49ab-bc14-a32252e69f33"),
                Title =("Security"),
                Url = ("SecOps"),
                Summary = ("Aprenda a proteger seus Docker Files"),
                Order = 9,
                Description = "Aprenda SecOps",
                Featured = true
            });
            Console.WriteLine("\nUpdating Category");
            Console.WriteLine("------------------------------------");  
            System.Console.WriteLine($"{updateRows} Data Updated");
        }
        #endregion
        #region Deleting one Category Row
        public static void deleteCategory(SqlConnection connection)
        {
            var deleteQuery = @" DELETE FROM [CATEGORY] WHERE [Id]= @id";
            var deleteRows = connection.Execute(deleteQuery, new
            {
                //Id = ("52100872-02b4-4f17-9654-bffd4e8bf9c9"),
                //Id = ("bd9eb6e2-7cad-4eae-8e4c-d75bdbfd1498")
                Id = ("1dfa7731-b21d-423e-b83a-e1b07058f7bf")
            }
            );
            Console.WriteLine("\nDeleting Category");
            Console.WriteLine("------------------------------------");
            System.Console.WriteLine($"{deleteRows} Row Deleted");
        }
        #endregion
        #region Deleting an Procedure 
        public static void deleteProcedure(SqlConnection connection)
        {
            var prc = "spDeleteStudent";
            var pars = new {StudentId = "2a8dfd4d-cf67-4bc9-bd40-b99e1f17324f"};
            var rows = connection.Execute(prc,pars,commandType: System.Data.CommandType.StoredProcedure);
            Console.WriteLine("\nUsing an Procedure");
            Console.WriteLine("------------------------------------");
            Console.WriteLine(rows);
            
        }
        #endregion 
        #region Doing de Like filter 
        public static void doLike(SqlConnection connection)
        {
            var query = "SELECT * FROM [CATEGORY] WHERE [TITLE] LIKE @exp";
            var itens = connection.Query<Category>(query,new{
                
                exp = "Frontend"

            });
            Console.WriteLine("Using The <LIKE> Command");
            foreach (var item in itens)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine(item.Title);
                break;                
            }

        }
        #endregion 
    }
}