using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuestionsApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionsApplication.DAL {
    public class QuestionsContext : DbContext {
        public QuestionsContext() : base() {
        }
        public QuestionsContext(DbContextOptions<QuestionsContext> options) : base(options) {
        }

        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Test>().HasMany<Question>(t => t.Questions);
            modelBuilder.Entity<Question>().HasMany<Test>(q => q.Tests);
            base.OnModelCreating(modelBuilder);
        }

        public static void SeedData(IServiceProvider serviceProvider) {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope()) {
                var context = serviceScope.ServiceProvider.GetService<QuestionsContext>();
                context.Database.EnsureCreated();
                if (context.Tests.Any()) return;
                context.Tests.AddRange(new List<Test> {
                    new Test {
                        Questions = new List<Question>() {
                            new Question {
                                Content = "How are you?",
                                Answer = "Como estas?"
                            }
                        },
                        Name = "Spanish 1",
                    },
                    new Test {
                        Questions = new List<Question>() {
                            new Question {
                                Content = "Good day!",
                                Answer = "Buen dia!"
                            }
                        },
                        Name = "Spanish 2",
                    }
                });
                context.SaveChanges();
            }
        }
    }
}
