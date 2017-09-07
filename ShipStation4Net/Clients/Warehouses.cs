﻿#region License
/*
 * Copyright 2017 Brandon James
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */
#endregion

using ShipStation4Net.Clients.Interfaces;
using ShipStation4Net.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShipStation4Net.Clients
{
    public class Warehouses : ClientBase, IListsItems<Warehouse>, IGets<Warehouse>, IUpdates<Warehouse>, ICreates<Warehouse>
    {
        public Warehouses(Configuration configuration) : base(configuration)
        {
            BaseUri = "warehouses";
        }

        /// <summary>
        /// Adds a Ship From Location (formerly known as warehouse) to your account. 
        /// </summary>
        /// <param name="newItem">The new warehouse to create.</param>
        /// <returns>The created warehouse.</returns>
        public Task<Warehouse> CreateAsync(Warehouse newItem)
        {
            return PostDataAsync(newItem);
        }

        public async Task<Warehouse> GetAsync(int id)
        {
            return await GetDataAsync<Warehouse>(id);
        }

        /// <summary>
        /// Updates an existing Ship From Location (formerly known as warehouse). This call does not currently support partial updates. 
        /// The entire resource must be provided in the body of the request. If a "returnAddress" object is not specified, your 
        /// "originAddress" will be used as your "returnAddress".
        /// </summary>
        /// <param name="id">
        /// A unique ID generated by ShipStation and assigned to each Ship From Location(formerly known as warehouse).
        /// Example: 12345678.</param>
        /// <param name="item">The warehouse data to update with.</param>
        /// <returns></returns>
        public async Task<Warehouse> UpdateAsync(int id, Warehouse item)
        {
            return await PutDataAsync(id, item);
        }

        /// <summary>
        /// Returns a list of active Ship From Locations(formerly known as warehouses) on the ShipStation account.Warehouses are now 
        /// called "Ship From Locations" in the UI.
        /// </summary>
        /// <returns>A list of active Ship From Locations.</returns>
        public async Task<IList<Warehouse>> GetItemsAsync()
        {
            return await GetDataAsync<IList<Warehouse>>();
        }
    }
}
