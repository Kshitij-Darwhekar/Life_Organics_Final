CREATE TABLE Products(
			  product_id int primary key IDENTITY(1,1),
		      name varchar(255),
		      original_price varchar(255),
		      selling_price integer,
		      category varchar(255),
		      details text,
			  pic image
			  );

SELECT * FROM Products;

INSERT INTO Products(name, original_price, selling_price, category, details, pic)
VALUES ('Orange', '150', '120', 'Fruits', 'Juicy and vitamin-rich oranges for a refreshing taste.',
        (SELECT BulkColumn FROM OPENROWSET(BULK 'C:\Users\KshitijDarwhekar\Pictures\Orange.jpg', SINGLE_BLOB) AS ImageData)
);

INSERT INTO Products(name, original_price, selling_price, category, details, pic)
VALUES ('Apple', '200', '180', 'Fruits', 'Fresh and crisp apples from local orchards.',
        (SELECT BulkColumn FROM OPENROWSET(BULK 'C:\Users\KshitijDarwhekar\Pictures\Apple.jpg', SINGLE_BLOB) AS ImageData)
);

INSERT INTO Products(name, original_price, selling_price, category, details, pic)
VALUES ('Banana', '50', '25', 'Fruits', 'Ripe and sweet bananas for a healthy snack.',
        (SELECT BulkColumn FROM OPENROWSET(BULK 'C:\Users\KshitijDarwhekar\Pictures\Banana.jpg', SINGLE_BLOB) AS ImageData)
);

INSERT INTO Products(name, original_price, selling_price, category, details, pic)
VALUES ('Carrot', '80', '65', 'Vegetables', 'Crunchy and nutritious carrots for salads or snacks.',
        (SELECT BulkColumn FROM OPENROWSET(BULK 'C:\Users\KshitijDarwhekar\Pictures\Carrot.jpg', SINGLE_BLOB) AS ImageData)
);

INSERT INTO Products(name, original_price, selling_price, category, details, pic)
VALUES ('Broccoli', '200', '190', 'Vegetables', 'Fresh broccoli packed with vitamins and minerals.',
        (SELECT BulkColumn FROM OPENROWSET(BULK 'C:\Users\KshitijDarwhekar\Pictures\Broccoli.jpg', SINGLE_BLOB) AS ImageData)
);

INSERT INTO Products(name, original_price, selling_price, category, details, pic)
VALUES ('Tomato', '40', '30', 'Vegetables', 'Ripe and juicy tomatoes for cooking or salads.',
        (SELECT BulkColumn FROM OPENROWSET(BULK 'C:\Users\KshitijDarwhekar\Pictures\Tomato.jpg', SINGLE_BLOB) AS ImageData)
);

INSERT INTO Products(name, original_price, selling_price, category, details, pic)
VALUES ('Spinach', '100', '80', 'Leafy Greens', 'Nutrient-packed spinach leaves for salads or smoothies.',
        (SELECT BulkColumn FROM OPENROWSET(BULK 'C:\Users\KshitijDarwhekar\Pictures\Spinach.jpeg', SINGLE_BLOB) AS ImageData)
);

INSERT INTO Products(name, original_price, selling_price, category, details, pic)
VALUES ('Kale', '140', '130', 'Leafy Greens', 'Healthy and flavorful kale for a variety of dishes.',
        (SELECT BulkColumn FROM OPENROWSET(BULK 'C:\Users\KshitijDarwhekar\Pictures\Kale.jpg', SINGLE_BLOB) AS ImageData)
);


INSERT INTO Products(name, original_price, selling_price, category, details, pic)
VALUES ('Lettuce', '240', '230', 'Leafy Greens', 'Crisp and fresh lettuce leaves for salads or wraps.',
        (SELECT BulkColumn FROM OPENROWSET(BULK 'C:\Users\KshitijDarwhekar\Pictures\Lettuce.jpg', SINGLE_BLOB) AS ImageData)
);
