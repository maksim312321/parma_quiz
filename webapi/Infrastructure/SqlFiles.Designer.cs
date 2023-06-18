﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webapi.Infrastructure {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SqlFiles {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SqlFiles() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("webapi.Infrastructure.SqlFiles", typeof(SqlFiles).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на INSERT INTO answers(
        ///    answer_text
        ///) 
        ///VALUES 
        ///  (
        ///    @AnswerText
        ///  ) RETURNING answer_id.
        /// </summary>
        internal static string AddNewAnswer {
            get {
                return ResourceManager.GetString("AddNewAnswer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на INSERT INTO questions(
        ///    question_text,
        ///    question_image,
        ///    question_correct_answer_id,
        ///    question_answer_ids,
        ///    is_open,
        ///    question_difficult_id,
        ///    question_video_link
        ///) 
        ///VALUES 
        ///  (
        ///    @QuestionText, 
        ///    @QuestionImage, 
        ///    @QuestionCorrectAnswerId, 
        ///    @QuestionAnswerIds,
        ///    @IsOpen,
        ///    @QuestionDifficultId,
        ///    @QuestionVideoLink
        ///  ) RETURNING question_id.
        /// </summary>
        internal static string AddNewQuestion {
            get {
                return ResourceManager.GetString("AddNewQuestion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на INSERT INTO users(
        ///    user_password,
        ///    user_name,
        ///    user_surname,
        ///    user_login,
        ///    user_role_id
        ///) 
        ///VALUES 
        ///  (
        ///    @UserPassword,
        ///    @UserName,
        ///    @UserSurname,
        ///    @UserLogin,
        ///    @UserRoleId
        ///  ) RETURNING user_id.
        /// </summary>
        internal static string AddNewUser {
            get {
                return ResourceManager.GetString("AddNewUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на INSERT INTO user_answers(
        ///    user_answer_text,
        ///    answer_id,
        ///    user_id,
        ///    is_correct
        ///) 
        ///VALUES 
        ///  (
        ///    @UserAnswerText,
        ///    @AnswerId,
        ///    @UserId,
        ///    @IsCorrect
        ///  )
        ///  RETURNING user_answer_id.
        /// </summary>
        internal static string AddNewUserAnswer {
            get {
                return ResourceManager.GetString("AddNewUserAnswer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на DELETE FROM answers where answer_id = @AnswerId.
        /// </summary>
        internal static string DeleteAnswerById {
            get {
                return ResourceManager.GetString("DeleteAnswerById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на DELETE from questions where question_id = @QuestionId.
        /// </summary>
        internal static string DeleteQuestionById {
            get {
                return ResourceManager.GetString("DeleteQuestionById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на DELETE FROM users where user_id = @UserId.
        /// </summary>
        internal static string DeleteUserById {
            get {
                return ResourceManager.GetString("DeleteUserById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на select a.answer_id as AnswerId,
        ///											a.answer_text as AnswerText									   
        ///									from answers a.
        /// </summary>
        internal static string GetAllAnswers {
            get {
                return ResourceManager.GetString("GetAllAnswers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на select q.question_id as QuestionId,
        ///           q.question_text as QuestionText,
        ///           q.question_image as QuestionImage,
        ///           q.question_correct_answer_id as CorrectAnswerId,
        ///           q.question_answer_ids as QuestionAnswerIds,
        ///           q.is_open as IsOpen,
        ///           q.question_difficult_id as QuestionDifficultId,
        ///           q.question_video_link as QuestionVideoLink
        ///         from questions q.
        /// </summary>
        internal static string GetAllQuestions {
            get {
                return ResourceManager.GetString("GetAllQuestions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на SELECT u.user_answer_id as UserAnswerId,
        ///                        u.user_answer_text as UserAnswerText,
        ///                        u.answer_id as AnswerId,
        ///                        u.user_id as UserId,
        ///                        u.is_correct as IsCorrect,
        ///                        u.question_id as QuestionId
        ///                        from user_answers u where u.user_id = @UserId.
        /// </summary>
        internal static string GetAllUserAnswersByUserId {
            get {
                return ResourceManager.GetString("GetAllUserAnswersByUserId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на select u.user_id as UserId,
        ///											u.user_password as UserPassword,
        ///										   	u.user_name as UserName,
        ///										   	u.user_surname as UserSurname,
        ///										  	u.user_login as UserLogin,
        ///										  	u.user_role_id as RoleId
        ///                                           	from users u.
        /// </summary>
        internal static string GetAllUsers {
            get {
                return ResourceManager.GetString("GetAllUsers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на select a.answer_id as AnswerId,
        ///											a.answer_text as AnswerText									   
        ///									from answers a
        ///									where a.answer_id = ANY(@AnswerIds).
        /// </summary>
        internal static string GetAnswersByIds {
            get {
                return ResourceManager.GetString("GetAnswersByIds", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на select q.question_id as QuestionId,
        ///											q.question_text as QuestionText,
        ///										   	q.question_image as QuestionImage,
        ///										   	q.question_correct_answer_id as CorrectAnswerId,
        ///										  	q.question_answer_ids as QuestionAnswerIds,
        ///										  	q.is_open as IsOpen,
        ///                                            q.question_difficult_id as QuestionDifficultId,
        ///										   	q.question_video_link as QuestionVideoLink
        ///									from questions q 
        ///									where q.question_id = @QuestionId.
        /// </summary>
        internal static string GetQuestionById {
            get {
                return ResourceManager.GetString("GetQuestionById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на SELECT u.user_answer_id as UserAnswerId,
        ///                        u.user_answer_text as UserAnswerText,
        ///                        u.answer_id as AnswerId,
        ///                        u.user_id as UserId,
        ///                        u.is_correct as IsCorrect,
        ///                        u.question_id as QuestionId
        ///                        from user_answers u where u.user_answer_id = @UserAnswerId.
        /// </summary>
        internal static string GetUserAnswerById {
            get {
                return ResourceManager.GetString("GetUserAnswerById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на SELECT u.user_answer_id as UserAnswerId,
        ///                        u.user_answer_text as UserAnswerText,
        ///                        u.answer_id as AnswerId,
        ///                        u.user_id as UserId,
        ///                        u.is_correct as IsCorrect,
        ///                        u.question_id as QuestionId
        ///                        from user_answers u where u.question_id = @QuestionId.
        /// </summary>
        internal static string GetUserAnswerByQuestionId {
            get {
                return ResourceManager.GetString("GetUserAnswerByQuestionId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на select u.user_id as UserId,
        ///											u.user_password as UserPassword,
        ///										   	u.user_name as UserName,
        ///										   	u.user_surname as UserSurname,
        ///										  	u.user_login as UserLogin,
        ///										  	u.user_role_id as RoleId
        ///                                           	from users u
        ///                                            where u.user_id = @UserId.
        /// </summary>
        internal static string GetUserById {
            get {
                return ResourceManager.GetString("GetUserById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на select u.user_id as UserId,
        ///											u.user_password as UserPassword,
        ///										   	u.user_name as UserName,
        ///										   	u.user_surname as UserSurname,
        ///										  	u.user_login as UserLogin,
        ///										  	u.user_role_id as RoleId
        ///                                           	from users u
        ///                                            where u.user_login = @UserLogin.
        /// </summary>
        internal static string GetUserByLogin {
            get {
                return ResourceManager.GetString("GetUserByLogin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на UPDATE user_answers
        ///SET
        ///is_correct=@IsCorrect,
        ///user_answer_text=@UserAnswerText,
        ///answer_id = @AnswerId
        ///WHERE user_answer_id=@UserAnswerId
        ///.
        /// </summary>
        internal static string UpdateUserAnswer {
            get {
                return ResourceManager.GetString("UpdateUserAnswer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на UPDATE users
        ///SET user_password=@UserPassword,
        ///    user_name=@UserName,
        ///    user_surname=@UserSurname,
        ///    user_login=@UserLogin,
        ///    user_role_id=@UserRoleId
        ///WHERE user_id= @UserId
        ///RETURNING user_id
        ///.
        /// </summary>
        internal static string UpdateUserById {
            get {
                return ResourceManager.GetString("UpdateUserById", resourceCulture);
            }
        }
    }
}
