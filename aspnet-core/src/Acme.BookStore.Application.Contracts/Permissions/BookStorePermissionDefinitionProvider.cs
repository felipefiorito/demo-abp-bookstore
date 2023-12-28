﻿using Acme.BookStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.BookStore.Permissions;

public class BookStorePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var bookStoreGroup = context.AddGroup(BookStorePermissions.GroupName, L("Permission:BookStore"));

        var booksPermission = bookStoreGroup.AddPermission(BookStorePermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(BookStorePermissions.Books.Create, L("Permission:Books:Create"));
        booksPermission.AddChild(BookStorePermissions.Books.Edit, L("Permission:Books:Edit"));
        booksPermission.AddChild(BookStorePermissions.Books.Delete, L("Permission:Books:Delete"));

        var authorsPermission =
            bookStoreGroup.AddPermission(BookStorePermissions.Authors.Default, L("Permission:Authors"));
        authorsPermission.AddChild(BookStorePermissions.Authors.Create, L("Premissions:Authors:Create"));
        authorsPermission.AddChild(BookStorePermissions.Authors.Edit, L("Premissions:Authors:Edit"));
        authorsPermission.AddChild(BookStorePermissions.Authors.Delete, L("Premissions:Authors:Delete"));


        //Define your own permissions here. Example:
        //myGroup.AddPermission(BookStorePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BookStoreResource>(name);
    }
}
