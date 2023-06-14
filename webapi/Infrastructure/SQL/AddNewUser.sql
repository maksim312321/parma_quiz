INSERT INTO users(
    user_password,
    user_name,
    user_surname,
    user_login,
    user_role_id
) 
VALUES 
  (
    @UserPassword,
    @UserName,
    @UserSurname,
    @UserLogin,
    @UserRoleId
  ) RETURNING user_id