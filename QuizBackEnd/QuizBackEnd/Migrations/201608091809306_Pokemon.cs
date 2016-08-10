namespace QuizBackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pokemon : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PokemonModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Nombre = c.String(),
                        TipoPrincipal = c.String(),
                        TipoSecundario = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PokemonModels");
        }
    }
}
