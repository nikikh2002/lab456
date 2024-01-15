using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using lab456.Models;
using CloudKit;
using ObjCRuntime;
using System.Collections;
using StoreKit;
namespace lab456.Date
{
    public Class ShoppingListDatabase
    { 
 readonly SQLiteAsyncConnection _database;
 public ShoppingListDatabase(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<ShopList>().Wait();
        _ database.CreateTableAsync<Product>().Wait();
        _ database.CreateTableAsync<ListProduct>().Wait();
    }
    public Task<int> SaveProductAsync(Product product)
    {
        if (product.ID != 0)
        {
            return _ database.UpdateAsync(product);
        }
        else
        {
            return _ database.InsertAsync(product);
        }
    }
    public Task<int> DeleteProductAsync(Product product)
    {
        return _ database.DeleteAsync(product);
    }
    public Task<List<Product>> GetProductsAsync()
    {
        return _ database.Table<Product>().ToListAsync();
    }
} 
}
    }
    public Task<List<ShopList>> GetShopListsAsync()
    {
        return _database.Table<ShopList>().ToListAsync();
    }
    public Task<ShopList> GetShopListAsync(int id)
    {
        return _database.Table<ShopList>()
       .Where(i => i.ID == id)
       .FirstOrDefaultAsync();
    }
    public Task<int> SaveShopListAsync(ShopList slist)
    {
        if (slist.ID != 0)
        {
            return _database.UpdateAsync(list);

        }
        else
        {
            return _database.InsertAsync(slist);
        }
    }
    public Task<int> DeleteShopListAsync(ShopList slist)
    {
        return _database.DeleteAsync(list);
    }
public Task<int> SaveListProductAsync(ListProduct listp)
{
    if (listp.ID != 0)
    {
        return _ database.UpdateAsync(listp);
    }
    else
    {
        return _ database.InsertAsync(listp);
    }
}
public Task<List<Product>> GetListProductsAsync(int shoplistid)
{
    return _ database.QueryAsync<Product>(
    " select P.ID, P.Description from Product P"
   + "inner join ListProduct LP"
   + " on P.ID = LP.ProductID where LP.ShopListID = ?",
    shoplistid);
}
} 
}