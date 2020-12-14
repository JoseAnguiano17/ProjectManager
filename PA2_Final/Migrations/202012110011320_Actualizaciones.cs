namespace PA2_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Actualizaciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actualizacions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Costo = c.Double(nullable: false),
                        Proyecto_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Proyectoes", t => t.Proyecto_ID)
                .Index(t => t.Proyecto_ID);
            
            AddColumn("dbo.Proyectoes", "Nombre", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Proyectoes", "Costo", c => c.Double(nullable: false));
            AlterColumn("dbo.Proyectoes", "Descripcion", c => c.String(nullable: false));
            AlterColumn("dbo.Errors", "Descripcion", c => c.String(nullable: false));
            AlterColumn("dbo.Sugerencias", "Descripcion", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Actualizacions", "Proyecto_ID", "dbo.Proyectoes");
            DropIndex("dbo.Actualizacions", new[] { "Proyecto_ID" });
            AlterColumn("dbo.Sugerencias", "Descripcion", c => c.String());
            AlterColumn("dbo.Errors", "Descripcion", c => c.String());
            AlterColumn("dbo.Proyectoes", "Descripcion", c => c.String());
            DropColumn("dbo.Proyectoes", "Costo");
            DropColumn("dbo.Proyectoes", "Nombre");
            DropTable("dbo.Actualizacions");
        }
    }
}
