select u.user_id as UserId,
											u.user_password as UserPassword,
										   	u.user_name as UserName,
										   	u.user_surname as UserSurname,
										  	u.user_login as UserLogin,
										  	u.user_role_id as RoleId
                                           	from users u