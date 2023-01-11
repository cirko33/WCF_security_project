﻿using LDBContracts;
using System;
using Common;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class WCFClient : ChannelFactory<ILocalService>, ILocalService, IDisposable
    {
        ILocalService factory;
        public WCFClient(NetTcpBinding binding, EndpointAddress address) : base(binding, address)
        {
            factory = this.CreateChannel();
        }


        public void AddNew(byte[] region, byte[] year, byte[] city, Dictionary<byte[], byte[]> expensesPerMonth)
        {
            try
            {
                Console.WriteLine("Sending request for adding expense!");
                factory.AddNew(region, year, city, expensesPerMonth);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DeleteExpense(byte[] id)
        {
            try
            {
                Console.WriteLine("Sending request for deleting expense!");
                factory.DeleteExpense(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public byte[] GetAverageValueForCity(byte[] city)
        {
            byte[] retVal = null;
            try
            {
                Console.WriteLine("Sending request for average city expense!");
                retVal = factory.GetAverageValueForCity(city);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return retVal;
        }

        public byte[] GetAverageValueForRegion(byte[] region)
        {
            byte[] retVal = null;
            try
            {
                Console.WriteLine("Sending request for average region expense!");
                retVal = factory.GetAverageValueForRegion(region);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return retVal;
        }

        public List<byte[]> ReadDataRegion(byte[] region)
        {
            List<byte[]> retVal = null;
            try
            {
                retVal = factory.ReadDataRegion(region);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return retVal;
        }


        public void UpdateCurrentMonthUsage(byte[] region, byte[] city, byte[] value)
        {
            try
            {
                factory.UpdateCurrentMonthUsage(region, city, value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<byte[]> ReadData()
        {
            List<byte[]> retVal = null;
            try
            {
                retVal = factory.ReadData();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return retVal;
        }
    }
}
