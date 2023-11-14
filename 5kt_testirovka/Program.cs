using System;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using Newtonsoft.Json;
using NUnitLite;
using NUnit.Framework;
[TestFixture]
class HTTPS
{
    static async Task Main(string[] args)
    {
        string baseUrl = "https://petstore.swagger.io#";

        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(baseUrl);

        // Значения для использования запросов
        string username = "newUser";
        string password = "123";
        string orderId = "1";

        await CreateUserAsync(client, username, password);
        await GetUserInfoAsync(client, username);
        await LoginUserAsync(client, username, password);
        await LogoutUserAsync(client);
        await CreateOrderAsync(client, orderId);
        await GetStoreInventoryAsync(client);
        await GetOrderInfoAsync(client, orderId);
        await DeleteOrderAsync(client, orderId);
    }
    [Test]
    [AllureLink("https://example.com/allure-report/")]
    [AllureFeature("Feature1")]
    [AllureStory("Story1")]
    static async Task CreateUserAsync(HttpClient client, string username, string password)
    {
        // Создание нового пользователя
        string createUserUrl = "/v2/user";
        string newUserJson = "{\"id\": 0, \"username\": \"newUser\", \"email\": \"newuser@example.com\", \"password\": \"123\", \"userStatus\": 1}";
        HttpResponseMessage createUserResponse = await client.PostAsync(createUserUrl, new StringContent(newUserJson, System.Text.Encoding.UTF8, "application/json"));
        string createUserResult = await createUserResponse.Content.ReadAsStringAsync();
        Console.WriteLine($"Результат создания пользователя: {createUserResult}\n");
    }
    [Test]
    [AllureLink("https://example.com/allure-report/")]
    [AllureFeature("Feature1")]
    [AllureStory("Story1")]
    static async Task GetUserInfoAsync(HttpClient client, string username)
    {
        // Получение информации о пользователе
        string getUserUrl = $"/v2/user/{username}";
        HttpResponseMessage getUserResponse = await client.GetAsync(getUserUrl);
        string getUserResult = await getUserResponse.Content.ReadAsStringAsync();
        Console.WriteLine($"Информация о пользователе: {getUserResult}");
    }
    [Test]
    [AllureLink("https://example.com/allure-report/")]
    [AllureFeature("Feature1")]
    [AllureStory("Story1")]
    static async Task LoginUserAsync(HttpClient client, string username, string password)
    {
        // Реализация входа
        string loginUserUrl = $"/v2/user/login?username={username}&password={password}";
        HttpResponseMessage loginUserResponse = await client.GetAsync(loginUserUrl);
        string loginUserResult = await loginUserResponse.Content.ReadAsStringAsync();
        Console.WriteLine($"Результат входа: {loginUserResult}\n");
    }
    [Test]
    [AllureLink("https://example.com/allure-report/")]
    [AllureFeature("Feature1")]
    [AllureStory("Story1")]
    static async Task LogoutUserAsync(HttpClient client)
    {
        // Реализация выхода
        string logoutUserUrl = "/v2/user/logout";
        HttpResponseMessage logoutUserResponse = await client.GetAsync(logoutUserUrl);
        string logoutUserResult = await logoutUserResponse.Content.ReadAsStringAsync();
        Console.WriteLine($"Результат выхода: {logoutUserResult}\n");
    }
    [Test]
    [AllureLink("https://example.com/allure-report/")]
    [AllureFeature("Feature1")]
    [AllureStory("Story1")]
    static async Task CreateOrderAsync(HttpClient client, string orderId)
    {
        // Создание нового заказа
        string placeOrderUrl = "/v2/store/order";
        string newOrderJson = "{\"id\":1,\"petId\":1,\"quantity\":1,\"shipDate\":\"2023-11-06T18:51:42.698Z\",\"status\":\"placed\",\"complete\":\"true\"}";
        HttpResponseMessage placeOrderResponse = await client.PostAsync(placeOrderUrl, new StringContent(newOrderJson, System.Text.Encoding.UTF8, "application/json"));
        string placeOrderResult = await placeOrderResponse.Content.ReadAsStringAsync();
        Console.WriteLine($"Результат создания нового заказа: {placeOrderResult}\n");
    }
    [Test]
    [AllureLink("https://example.com/allure-report/ ")]
    [AllureFeature("Feature1")]
    [AllureStory("Story1")]
    static async Task GetStoreInventoryAsync(HttpClient client)
    {
        // Получение информации о товарах в магазине
        string getStoreInventoryUrl = "/v2/store/inventory";
        HttpResponseMessage getStoreInventoryResponse = await client.GetAsync(getStoreInventoryUrl);
        string getStoreInventoryResult = await getStoreInventoryResponse.Content.ReadAsStringAsync();
        Console.WriteLine($"Информация о товарах в магазине: {getStoreInventoryResult}\n");
    }
    [Test]
    [AllureLink("https://example.com/allure-report/")]
    [AllureFeature("Feature1")]
    [AllureStory("Story1")]
    static async Task GetOrderInfoAsync(HttpClient client, string orderId)
    {
        // Получение информации о заказе
        string getOrderUrl = $"/v2/store/order/{orderId}";
        HttpResponseMessage getOrderResponse = await client.GetAsync(getOrderUrl);
        string getOrderResult = await getOrderResponse.Content.ReadAsStringAsync();
        Console.WriteLine($"Информация о заказе: {getOrderResult}\n");
    }
    [Test]
    [AllureLink("https://example.com/allure-report/")]
    [AllureFeature("Feature1")]
    [AllureStory("Story1")]
    static async Task DeleteOrderAsync(HttpClient client, string orderId)
    {
        // Реализация удаления заказа
        string deleteOrderUrl = $"/v2/store/order/{orderId}";
        HttpResponseMessage deleteOrderResponse = await client.DeleteAsync(deleteOrderUrl);
        string deleteOrderResult = await deleteOrderResponse.Content.ReadAsStringAsync();
        Console.WriteLine($"Результат удаления заказа: {deleteOrderResult}\n");
    }
}
