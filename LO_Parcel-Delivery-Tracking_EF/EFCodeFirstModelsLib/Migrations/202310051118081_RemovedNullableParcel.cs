namespace EFCodeFirstModelsLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedNullableParcel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Parcels", "parcel_status", c => c.String(nullable: false));
            AlterColumn("dbo.Parcels", "additional_notes", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parcels", "additional_notes", c => c.String(maxLength: 255));
            AlterColumn("dbo.Parcels", "parcel_status", c => c.String());
        }
    }
}
