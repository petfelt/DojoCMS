CREATE DATABASE user_db;
CREATE TABLE Users(
    id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(30) NOT NULL,
    email VARCHAR(60) NOT NULL,
    password VARCHAR(50) NOT NULL,
    created_at TIMESTAMP);
    
CREATE TABLE Posts(
    id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    created_by INT UNSIGNED NOT NULL,
    post TEXT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP);
    
CREATE TABLE Comments(
    id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    posted_by INT UNSIGNED NOT NULL,
    comment_for INT UNSIGNED NOT NULL,
    comment VARCHAR(200) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP);
    