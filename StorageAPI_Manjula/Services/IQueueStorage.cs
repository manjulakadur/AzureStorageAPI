﻿namespace StorageAPI_Manjula.Services
{
    public interface IQueueStorage
    {
        Task<bool> SendMessage(string queueName, string message);
        Task<List<string>> ReceiveMessages(string queueName);
        Task UpdateMessage(string queueName);
        Task DeleteMessage(string queueName);
    }
}
