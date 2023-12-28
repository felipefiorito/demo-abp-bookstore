using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualBasic.CompilerServices;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Acme.BookStore.Books;

public class Book : AuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid? TenantId { get; }
    public string Name { get; set; }
    public BookType Type { get; set; }
    public DateTime PublishDate { get; set; }
    public float Price { get; set; }
    
    // protected Book()
    // {
    //
    // }

    // public virtual void ChangeName([NotNull] string name)
    // {
    //     Name = CheckName(name);
    // }
    //
    // private static string CheckName(string name)
    // {
    //     if (string.IsNullOrWhiteSpace((name)))
    //     {
    //         throw new ArgumentException($"name can not be empty or white space!");
    //     }
    //
    //     if (name.Length > MaxNameLength)
    //     {
    //         throw new ArgumentException($"name can not be longer than {MaxNameLength} chars!");
    //     }
    //
    //     return name;
    // }
    
}
