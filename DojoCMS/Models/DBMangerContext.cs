using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using MySQL.Data.EntityFrameworkCore.Extensions;
using DojoCMS.Models;

namespace DojoCMS
{
    public class DBMangerContext : DbContext {
        
        // base() calls the parent class' constructor passing the "options" parameter along
        public DBMangerContext(DbContextOptions<BloggingContext> options):base(options){

        }       
        public DbSet<User> Users { get; set; }       


       
    }
}