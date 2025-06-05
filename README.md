# RoleBasedProductAPI
Login 
![image](https://github.com/user-attachments/assets/98894e32-6dc1-4c35-8457-41d865310fef)

Register
![image](https://github.com/user-attachments/assets/062b3f61-0600-480b-b23d-f99fb6ed7732)


fontend Dashboard
![image](https://github.com/user-attachments/assets/8ddf0b2e-7e6f-411e-8298-6bc568ca5b32)



## Product API Endpoints

This API allows managing products and their prices.

- `GET /api/products` - list all products
- `GET /api/products/{id}` - get a product by id
- `POST /api/products` - create a new product
- `PUT /api/products/{id}` - update an existing product
- `DELETE /api/products/{id}` - delete a product

A sample request to create a product using `curl`:

```bash
curl -X POST https://localhost:5001/api/products \
     -H "Content-Type: application/json" \
     -d '{"name":"Sample","price":99.99}'
```

