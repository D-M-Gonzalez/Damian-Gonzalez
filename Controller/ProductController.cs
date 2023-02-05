﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CursoCoder.Helper;

namespace CursoCoder.Controller
{
    internal class ProductController
    {
        public static List<Product> GetProducts(string sCon)
        {
            List<Product> products = new List<Product>();
            DataSet dsProducts = new DataSet();

            SqlConnection connection = new SqlConnection(sCon);
            connection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from Producto", connection);
            sqlDataAdapter.Fill(dsProducts, "DAT");

            if (dsProducts.Tables.Contains("DAT") && dsProducts.Tables["DAT"].Rows.Count > 0)
            {
                DataTable dtDAT = dsProducts.Tables["DAT"];
                foreach (DataRow dr in dtDAT.Rows)
                {
                    Product product = new Product();

                    product.Id = Convert.ToInt32(dr["id"]);
                    if (dr["descripciones"] != DBNull.Value) product.Description = Convert.ToString(dr["Descripciones"]).Trim();
                    if (dr["costo"] != DBNull.Value) product.Cost = Convert.ToDecimal(dr["costo"]);
                    if (dr["precioventa"] != DBNull.Value) product.SellingPrice = Convert.ToDecimal(dr["precioventa"]);
                    if (dr["stock"] != DBNull.Value) product.Stock = Convert.ToInt32(dr["stock"]);
                    if (dr["idusuario"] != DBNull.Value) product.UserId = Convert.ToInt32(dr["idusuario"]);

                    products.Add(product);

                }
            }

            connection.Close();

            return products;
        }

        public static Product GetProduct(Int32 productId)
        {
            Product product = new Product();
            SqlHandler sqlHandler = new SqlHandler();
            DataSet dsProduct = new DataSet();
            SqlCommand selectCommand = new SqlCommand("select * from Producto where Id=@productId");

            var parameter = new SqlParameter();
            parameter.ParameterName = "productId";
            parameter.SqlDbType = SqlDbType.BigInt;
            parameter.Value = productId;

            selectCommand.Parameters.Add(parameter);
            sqlHandler.GetCommand(dsProduct, selectCommand);

            if (dsProduct.Tables.Contains("DAT") && dsProduct.Tables["DAT"].Rows.Count > 0)
            {
                DataRow dr = dsProduct.Tables["DAT"].Rows[0];
                    product.Id = Convert.ToInt32(dr["id"]);
                    if (dr["descripciones"] != DBNull.Value) product.Description = Convert.ToString(dr["Descripciones"]).Trim();
                    if (dr["costo"] != DBNull.Value) product.Cost = Convert.ToDecimal(dr["costo"]);
                    if (dr["precioventa"] != DBNull.Value) product.SellingPrice = Convert.ToDecimal(dr["precioventa"]);
                    if (dr["stock"] != DBNull.Value) product.Stock = Convert.ToInt32(dr["stock"]);
                    if (dr["idusuario"] != DBNull.Value) product.UserId = Convert.ToInt32(dr["idusuario"]);

            }
            return product;
        }
    }
}
