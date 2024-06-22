using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Infrastructure.DatabaseContext;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRoles> UserRoles { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Municipality> Municipalities { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Parent> Parents { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<TeacherSubjects> TeacherSubjects { get; set; }
    public DbSet<EnrollmentYear> EnrollmentYears { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<ExamType> ExamTypes { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<EnrollmentExam> EnrollmentExams { get; set; }
    public DbSet<ExamResult> ExamResults { get; set; }
    public DbSet<FeeType> FeeTypes { get; set; }
    public DbSet<DiscountType> DiscountTypes { get; set; }
    public DbSet<FeeStructure> FeeStructures { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region User
        modelBuilder.Entity<User>()
            .HasKey(u => u.UserId);
        modelBuilder.Entity<User>()
            .Property(u => u.FirstName)
            .HasColumnType("Varchar(20)")
            .IsRequired();
        modelBuilder.Entity<User>()
            .Property(u => u.LastName)
            .HasColumnType("Varchar(20)")
            .IsRequired();
        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .HasColumnType("Varchar(50)")
            .IsRequired();
        modelBuilder.Entity<User>()
            .Property(u => u.Password)
            .HasColumnType("Varchar(250)")
            .IsRequired();
        modelBuilder.Entity<User>()
            .Property(u => u.ContactNumber)
            .HasColumnType("Varchar(20)")
            .IsRequired();
        modelBuilder.Entity<User>()
            .Property(u => u.IsActive)
            .HasColumnType("bit")
            .IsRequired()
            .HasDefaultValue(true);
        #endregion

        #region Role
        modelBuilder.Entity<Role>()
            .HasKey(r => r.RoleId);
        modelBuilder.Entity<Role>()
            .Property(r => r.Name)
            .HasColumnType("Varchar(20)")
            .IsRequired();
        modelBuilder.Entity<Role>()
            .Property(r => r.IsAdmin)
            .HasDefaultValue(false)
            .IsRequired();
        modelBuilder.Entity<Role>()
            .Property(r => r.IsActive)
            .HasColumnType("bit")
            .HasDefaultValue(true);
        #endregion

        #region UserRoles
        modelBuilder.Entity<UserRoles>()
            .HasKey(ur => ur.UserRoleId);

        modelBuilder.Entity<UserRoles>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRoles>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);

        #endregion

        #region Province
        modelBuilder.Entity<Province>()
            .HasKey(p => p.ProvinceId);

        modelBuilder.Entity<Province>()
            .HasMany(p => p.Districts)
            .WithOne(d => d.Province)
            .HasForeignKey(d => d.ProvinceId)
            .IsRequired();

        modelBuilder.Entity<Province>()
            .Property(p => p.ProvinceName)
            .HasColumnType("varchar(20)")
            .IsRequired();

        modelBuilder.Entity<Province>()
            .Property(p => p.IsActive)
            .HasColumnType("bit")
            .HasDefaultValue(true)
            .IsRequired();
        #endregion

        #region District
        modelBuilder.Entity<District>()
            .HasKey(d => d.DistrictId);

        modelBuilder.Entity<District>()
            .HasMany(d => d.Municipalities)
            .WithOne(d => d.District)
            .HasForeignKey(d => d.DistrictId)
            .IsRequired();

        modelBuilder.Entity<District>()
            .Property(d => d.DistrictName)
            .HasColumnType("varchar(20)")
            .IsRequired();


        modelBuilder.Entity<District>()
            .Property(d => d.IsActive)
            .HasColumnType("bit")
            .IsRequired()
            .HasDefaultValue(true);
        #endregion

        #region Municipality
        modelBuilder.Entity<Municipality>()
            .HasKey(m => m.MunicipalityId);

        modelBuilder.Entity<Municipality>()
            .Property(m => m.MunicipalityName)
            .HasColumnType("varchar(20)")
            .IsRequired();

        modelBuilder.Entity<Municipality>()
            .Property(m => m.IsActive)
            .HasColumnType("bit")
            .IsRequired()
            .HasDefaultValue(true);

        modelBuilder.Entity<Municipality>()
            .Property(m => m.WardCount)
            .HasColumnType("int")
            .IsRequired()
            .HasDefaultValue(0);
        #endregion

        #region Students
        modelBuilder.Entity<Student>()
            .HasKey(s => s.StudentId);

        modelBuilder.Entity<Student>()
            .Property(s => s.StudentNumber)
            .HasColumnType("varchar(20)")
            .IsRequired(true);

        modelBuilder.Entity<Student>()
            .Property(s => s.FirstName)
            .HasColumnType("varchar(50)")
            .IsRequired();

        modelBuilder.Entity<Student>()
            .Property(s => s.MiddleName)
            .HasColumnType("varchar(50)");

        modelBuilder.Entity<Student>()
            .Property(s => s.LastName)
            .HasColumnType("varchar(50)")
            .IsRequired();

        modelBuilder.Entity<Student>()
            .Property(s => s.DateOfBirth)
            .HasColumnType("DateTime")
            .IsRequired();

        modelBuilder.Entity<Student>()
            .Property(s => s.Gender)
            .HasColumnType("varchar(50)")
            .IsRequired();

        modelBuilder.Entity<Student>()
            .HasOne(s => s.Province)
            .WithMany(s => s.Students)
            .HasForeignKey(s => s.ProvinceId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        modelBuilder.Entity<Student>()
            .HasOne(s => s.District)
            .WithMany(s => s.Students)
            .HasForeignKey(s => s.DistrictId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        modelBuilder.Entity<Student>()
            .HasOne(s => s.Municipality)
            .WithMany(s => s.Students)
            .HasForeignKey(s => s.MunicipalityId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        modelBuilder.Entity<Student>()
            .Property(s => s.IsActive)
            .HasColumnType("bit")
            .IsRequired()
            .HasDefaultValue(1);

        modelBuilder.Entity<Student>()
            .Property(s => s.Status)
            .HasColumnType("varchar(20)")
            .IsRequired();
        #endregion

        #region Parent
        modelBuilder.Entity<Parent>()
            .HasKey(p => p.ParentId);

        modelBuilder.Entity<Parent>()
            .Property(p => p.FirstName)
            .HasColumnType("varchar(20)")
            .IsRequired();

        modelBuilder.Entity<Parent>()
            .Property(p => p.MiddleName)
            .HasColumnType("varchar(20)");

        modelBuilder.Entity<Parent>()
            .Property(p => p.LastName)
            .HasColumnType("varchar(20)")
            .IsRequired();

        modelBuilder.Entity<Parent>()
            .Property(p => p.Occupation)
            .HasColumnType("varchar(20)")
            .IsRequired();

        modelBuilder.Entity<Parent>()
            .HasOne(p => p.Student)
            .WithOne(p => p.Parent)
            .HasForeignKey<Parent>(p => p.StudentId)
            .IsRequired();


        modelBuilder.Entity<Parent>()
           .HasOne(p => p.User)
           .WithOne(p => p.Parent)
           .HasForeignKey<Parent>(p => p.UserId);



        modelBuilder.Entity<Parent>()
            .Property(p => p.IsActive)
            .HasColumnType("bit")
            .IsRequired()
            .HasDefaultValue(1);

        #endregion

        #region Employee

        modelBuilder.Entity<Employee>()
            .HasKey(e => e.EmployeeId);

        modelBuilder.Entity<Employee>()
            .Property(e => e.EmployeeNumber)
            .HasColumnType("varchar(20)")
            .IsRequired();

        modelBuilder.Entity<Employee>()
            .Property(e => e.FirstName)
            .HasColumnType("varchar(20)")
            .IsRequired();

        modelBuilder.Entity<Employee>()
            .Property(e => e.MiddleName)
            .HasColumnType("varchar(20)")
            .IsRequired();

        modelBuilder.Entity<Employee>()
            .Property(e => e.LastName)
            .HasColumnType("varchar(20)")
            .IsRequired();

        modelBuilder.Entity<Employee>()
            .Property(e => e.JoiningDate)
            .HasColumnType("DateTime")
            .IsRequired();
        modelBuilder.Entity<Employee>()
            .Property(e => e.Qualification)
            .HasColumnType("varchar(200)")
            .IsRequired();
        modelBuilder.Entity<Employee>()
            .Property(e => e.ExperienceInfo)
            .HasColumnType("varchar(400)")
            .IsRequired();
        modelBuilder.Entity<Employee>()
            .Property(e => e.Gender)
            .HasColumnType("varchar(20)")
            .IsRequired();

        modelBuilder.Entity<Employee>()
            .Property(e => e.DateOfBirth)
            .HasColumnType("DateTime")
            .IsRequired();

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Province)
            .WithMany(e => e.Employees)
            .HasForeignKey(e => e.ProvinceId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.District)
            .WithMany(e => e.Employees)
            .HasForeignKey(e => e.DistrictId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Municipality)
            .WithMany(e => e.Employees)
            .HasForeignKey(e => e.MunicipalityId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        modelBuilder.Entity<Employee>()
           .HasOne(e => e.User)
           .WithOne(e => e.Employee)
           .HasForeignKey<Employee>(e => e.UserId);

        modelBuilder.Entity<Employee>()
            .Property(e => e.IsActive)
            .HasColumnType("bit")
            .IsRequired()
            .HasDefaultValue(1);

        modelBuilder.Entity<Employee>()
            .Property(e => e.Status)
            .HasColumnType("varchar(20)")
            .IsRequired();
        #endregion

        #region Class
        modelBuilder.Entity<Class>()
            .HasKey(c => c.ClassId);

        modelBuilder.Entity<Class>()
            .Property(c => c.ClassName)
            .HasColumnType("varchar(20)")
            .IsRequired();

        modelBuilder.Entity<Class>()
            .Property(e => e.IsActive)
            .HasColumnType("bit")
            .IsRequired()
            .HasDefaultValue(1);

        modelBuilder.Entity<Class>()
            .HasMany(c => c.Subjects)
            .WithOne(c => c.Class)
            .HasForeignKey(c => c.ClassId)
            .IsRequired();
        #endregion

        #region Subject
        modelBuilder.Entity<Subject>()
            .HasKey(s => s.SubjectId);

        modelBuilder.Entity<Subject>()
            .Property(s => s.SubjectName)
            .HasColumnType("varchar(50)")
            .IsRequired();

        modelBuilder.Entity<Subject>()
            .Property(s => s.Description)
            .HasColumnType("varchar(50)");

        modelBuilder.Entity<Subject>()
            .Property(s => s.Credits)
            .HasColumnType("varchar(50)");

        modelBuilder.Entity<Subject>()
            .Property(s => s.HoursPerWeek)
            .HasColumnType("int");

        modelBuilder.Entity<Subject>()
            .Property(s => s.IsActive)
            .HasColumnType("bit")
            .IsRequired()
            .HasDefaultValue(1);

        modelBuilder.Entity<Subject>()
            .HasOne(s => s.Class)
            .WithMany(c => c.Subjects)
            .HasForeignKey(c => c.ClassId)
            .IsRequired();
        #endregion

        #region TeacherSubjects
        modelBuilder.Entity<TeacherSubjects>()
            .HasKey(ts => ts.TeacherSubjectId);

        modelBuilder.Entity<TeacherSubjects>()
            .HasOne(ts => ts.Teacher)
            .WithMany(ts => ts.TeacherSubjects)
            .HasForeignKey(ts => ts.TeacherId)
            .IsRequired();

        modelBuilder.Entity<TeacherSubjects>()
            .HasOne(ts => ts.Subject)
            .WithMany(ts => ts.TeacherSubjects)
            .HasForeignKey(ts => ts.SubjectId)
            .IsRequired();
        #endregion

        #region EnrollmentYear
        modelBuilder.Entity<EnrollmentYear>()
            .HasKey(ey => ey.EnrollmentYearId);

        modelBuilder.Entity<EnrollmentYear>()
            .Property(ey => ey.EnrollemntYearName)
            .HasColumnType("varchar(20)")
            .IsRequired();

        modelBuilder.Entity<EnrollmentYear>()
            .Property(s => s.IsActive)
            .HasColumnType("bit")
            .IsRequired()
            .HasDefaultValue(1);
        #endregion

        #region Enrollment
        modelBuilder.Entity<Enrollment>()
            .HasKey(e => e.EnrollmentId);

        modelBuilder.Entity<Enrollment>()
            .HasMany(e => e.Students)
            .WithOne(e => e.Enrollment)
            .HasForeignKey(e => e.StudentId)
            .IsRequired();

        modelBuilder.Entity<Enrollment>()
            .HasMany(e => e.Classes)
            .WithOne(e => e.Enrollment)
            .HasForeignKey(e => e.ClassId)
            .IsRequired();

        modelBuilder.Entity<Enrollment>()
            .Property(e => e.EnrollmentYear)
            .HasColumnType("varchar(40)")
            .IsRequired();

        modelBuilder.Entity<Enrollment>()
            .Property(e => e.EnrollmentStatus)
            .HasColumnType("varchar(20)")
            .IsRequired();

        modelBuilder.Entity<Enrollment>()
            .Property(e => e.EnrollmentDate)
            .HasColumnType("DateTime")
            .IsRequired();

        modelBuilder.Entity<Enrollment>()
            .Property(s => s.IsActive)
            .HasColumnType("bit")
            .IsRequired()
            .HasDefaultValue(1);
        #endregion

        #region ExamType
        modelBuilder.Entity<ExamType>()
            .HasKey(et => et.ExamTypeId);

        modelBuilder.Entity<ExamType>()
            .Property(et => et.ExamTypeName)
            .HasColumnType("varchar(50)")
            .IsRequired();

        modelBuilder.Entity<ExamType>()
            .Property(et => et.IsActive)
            .HasColumnType("bit")
            .HasDefaultValue(1)
            .IsRequired();

        #endregion

        #region Exams
        modelBuilder.Entity<Exam>()
            .HasKey(e => e.ExamId);

        modelBuilder.Entity<Exam>()
            .HasOne(e => e.ExamType)
            .WithMany(e => e.Exams)
            .HasForeignKey(e => e.ExamTypeId);

        modelBuilder.Entity<Exam>()
            .HasMany(e => e.Classes)
            .WithOne(e => e.Exam)
            .HasForeignKey(e => e.ClassId);

        modelBuilder.Entity<Exam>()
            .HasMany(e => e.Subjects)
            .WithOne(e => e.Exam)
            .OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey(e => e.SubjectId);

        modelBuilder.Entity<Exam>()
            .Property(e => e.ExamDate)
            .HasColumnType("DateTime")
            .IsRequired();

        modelBuilder.Entity<Exam>()
            .Property(e => e.ExamTime)
            .HasColumnType("DateTime")
            .IsRequired();

        modelBuilder.Entity<Exam>()
            .Property(e => e.ToalMarks)
            .HasColumnType("decimal(7,2)")
            .IsRequired();

        modelBuilder.Entity<Exam>()
            .Property(e => e.PassMarks)
            .HasColumnType("decimal(7,2)")
            .IsRequired();

        modelBuilder.Entity<ExamType>()
            .Property(et => et.IsActive)
            .HasColumnType("bit")
            .HasDefaultValue(1)
            .IsRequired();
        #endregion

        #region EnrollemntExams
        modelBuilder.Entity<EnrollmentExam>()
            .HasKey(ee => ee.EnrollmentExamId);

        modelBuilder.Entity<EnrollmentExam>()
            .HasOne(ee => ee.Exam)
            .WithMany(ee => ee.EnrollmentExams)
            .HasForeignKey(ee => ee.ExamId);

        modelBuilder.Entity<EnrollmentExam>()
            .HasOne(ee => ee.Enrollment)
            .WithMany(ee => ee.EnrollmentExams)
            .HasForeignKey(ee => ee.EnrollmentId);
        #endregion

        #region ExamResult
        modelBuilder.Entity<ExamResult>()
            .HasKey(er => er.ExamResultId);

        modelBuilder.Entity<ExamResult>()
            .HasOne(er => er.Exam)
            .WithOne(er => er.ExamResult)
            .HasForeignKey<ExamResult>(er => er.ExamId);

        modelBuilder.Entity<ExamResult>()
            .HasOne(er => er.Student)
            .WithOne(er => er.ExamResult)
            .HasForeignKey<ExamResult>(er => er.StudentId);

        modelBuilder.Entity<ExamResult>()
            .Property(er => er.MarksObtained)
            .HasColumnType("decimal(7,2)")
            .IsRequired();

        modelBuilder.Entity<ExamResult>()
            .Property(et => et.IsActive)
            .HasColumnType("bit")
            .HasDefaultValue(1)
            .IsRequired();

        #endregion

        #region FeeType
        modelBuilder.Entity<FeeType>()
            .HasKey(ft => ft.FeeTypeId);

        modelBuilder.Entity<FeeType>()
            .Property(ft => ft.FeeTypeName)
            .HasColumnType("varchar(50)")
            .IsRequired();

        modelBuilder.Entity<FeeType>()
            .Property(ft => ft.FeeTypeDescription)
            .HasColumnType("varchar(400)");

        modelBuilder.Entity<FeeType>()
            .Property(s => s.IsActive)
            .HasColumnType("bit")
            .IsRequired()
            .HasDefaultValue(1);

        #endregion

        #region DiscountType
        modelBuilder.Entity<DiscountType>()
            .HasKey(dt => dt.DiscountTypeId);

        modelBuilder.Entity<DiscountType>()
            .Property(dt => dt.DiscountTypeName)
            .HasColumnType("varchar(50)")
            .IsRequired();

        modelBuilder.Entity<DiscountType>()
            .Property(dt => dt.DiscountDescription)
            .HasColumnType("varchar(400)");

        modelBuilder.Entity<DiscountType>()
            .Property(dt => dt.DiscountAmount)
            .HasColumnType("decimal(16,4)")
            .IsRequired();

        modelBuilder.Entity<DiscountType>()
            .Property(s => s.IsActive)
            .HasColumnType("bit")
            .IsRequired()
            .HasDefaultValue(1);
        #endregion

        #region FeeStructure
        modelBuilder.Entity<FeeStructure>()
            .HasKey(fs => fs.FeeStructureId);

        modelBuilder.Entity<FeeStructure>()
            .HasOne(fs => fs.Class)
            .WithOne(fs => fs.FeeStructure)
            .HasForeignKey<FeeStructure>(fs => fs.ClassId);

        modelBuilder.Entity<FeeStructure>()
            .HasMany(fs => fs.FeeTypes)
            .WithOne(fs => fs.FeeStructure)
            .HasForeignKey(fs => fs.FeeTypeId);

        modelBuilder.Entity<FeeStructure>()
            .Property(fs => fs.Amount)
            .HasColumnType("decimal(16,4)")
            .IsRequired();

        modelBuilder.Entity<FeeStructure>()
            .HasOne(fs => fs.DiscountType)
            .WithOne(fs => fs.FeeStructure)
            .HasForeignKey<FeeStructure>(fs => fs.DiscountTypeId);

        modelBuilder.Entity<FeeStructure>()
            .Property(s => s.IsActive)
            .HasColumnType("bit")
            .IsRequired()
            .HasDefaultValue(1);


        #endregion

    }
}
