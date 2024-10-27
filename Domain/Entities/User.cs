namespace Domain.Entities
{
    public class User
    {
        /// <summary>
        ///     Айди
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        ///     Имя
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        ///     Описание
        /// </summary>
        public string Bio { get; set; }
        
        /// <summary>
        ///     Почта
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        ///     Хэшированный пароль
        /// </summary>
        public string PasswordHash { get; set; }
        
        /// <summary>
        ///     Навыки
        /// </summary>
        public string Skills { get; set; }
        
        /// <summary>
        ///     Созданные проекты пользователя
        /// </summary>
        public ICollection<Project> CreatedProjects { get; set; } = new List<Project>();
        
        /// <summary>
        ///     Проекты в которых участвует пользователь
        /// </summary>
        public ICollection<Project> JoinedProjects { get; set; } = new List<Project>();
    }
}