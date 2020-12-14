namespace PA2_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        ApellidoPaterno = c.String(nullable: false, maxLength: 50),
                        ApellidoMaterno = c.String(maxLength: 50),
                        Telefono = c.String(maxLength: 30),
                        Correo = c.String(maxLength: 40),
                        RFC = c.String(nullable: false),
                        FechaAsoc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Proyectoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        Estado = c.Int(nullable: false),
                        Cliente_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clientes", t => t.Cliente_ID)
                .Index(t => t.Cliente_ID);
            
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        Estado = c.Int(nullable: false),
                        Proyecto_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Proyectoes", t => t.Proyecto_ID)
                .Index(t => t.Proyecto_ID);
            
            CreateTable(
                "dbo.Sugerencias",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        Estado = c.Int(nullable: false),
                        Proyecto_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Proyectoes", t => t.Proyecto_ID)
                .Index(t => t.Proyecto_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proyectoes", "Cliente_ID", "dbo.Clientes");
            DropForeignKey("dbo.Sugerencias", "Proyecto_ID", "dbo.Proyectoes");
            DropForeignKey("dbo.Errors", "Proyecto_ID", "dbo.Proyectoes");
            DropIndex("dbo.Sugerencias", new[] { "Proyecto_ID" });
            DropIndex("dbo.Errors", new[] { "Proyecto_ID" });
            DropIndex("dbo.Proyectoes", new[] { "Cliente_ID" });
            DropTable("dbo.Sugerencias");
            DropTable("dbo.Errors");
            DropTable("dbo.Proyectoes");
            DropTable("dbo.Clientes");
        }
    }
}
