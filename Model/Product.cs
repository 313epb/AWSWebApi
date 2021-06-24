namespace AWSWebApi.Model
{
    /// <summary>
    /// Продукт магазина
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Айди в базе
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public int Price { get; set; }
    }
}