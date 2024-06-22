namespace SERVER.QUERY.query;

public static class UserQuery
{
    public static string InsertUser => $"INSERT INTO \"Identity\".\"Users\"(\"FirstName\", \"MiddleName\", \"LastName\", \"UserName\", \"Email\", \"Phone\", \"Password\", \"Gender\", \"AddressId\", \"RoleId\", \"CreatedAt\")VALUES(@firstName,@middleName,@lastName,@userName,@email,@phone,@password,@gender,@addressId,@roleId,@createdAt);";
                                            
    public static string UpdataLogin => @"update ""Identity"".""Users"" set ""UpdatedAt"" = @UpdatedAt,""LastLogin"" = @LastLogin,
                                        ""LoginCount"" = @LoginCount, ""Otp"" = @Otp;";

}
