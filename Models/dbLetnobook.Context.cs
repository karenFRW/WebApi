﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class letnobookEntities : DbContext
    {
        public letnobookEntities()
            : base("name=letnobookEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tClass> tClasses { get; set; }
        public virtual DbSet<tCommunication> tCommunications { get; set; }
        public virtual DbSet<tDiary> tDiaries { get; set; }
        public virtual DbSet<tInfo> tInfoes { get; set; }
        public virtual DbSet<tParent> tParents { get; set; }
        public virtual DbSet<tStudent> tStudents { get; set; }
        public virtual DbSet<tTeacher> tTeachers { get; set; }
        public virtual DbSet<tTeachingData> tTeachingDatas { get; set; }
        public virtual DbSet<tTotal> tTotals { get; set; }
    }
}
