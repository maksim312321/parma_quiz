UPDATE users
SET user_password=@UserPassword,
    user_name=@UserName,
    user_surname=@UserSurname,
    user_login=@UserLogin,
    user_role_id=@UserRoleId
WHERE user_id= @UserId
RETURNING user_id
