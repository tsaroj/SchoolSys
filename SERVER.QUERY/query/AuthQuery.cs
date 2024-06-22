namespace SERVER.QUERY.query;

public static class AuthQuery
{
    // public static string UserByUSerName => @"select * from ""Identity"".""Users"" u 
    //                                         inner join ""Identity"".""Roles"" r on r.""Id""  = u.""RoleId""  
    //                                         where u.""UserName"" = :UserName;";
    public static string UserByUSerName => @"select * from ""Identity"".""Users"" u where u.""UserName"" = :UserName;";
    public static string UpdataLogin => @"update ""Identity"".""Users"" set ""UpdatedAt"" = @UpdatedAt,""LastLogin"" = @LastLogin,
                                        ""LoginCount"" = @LoginCount, ""Otp"" = @Otp where ""Id""=@Id ;";
}