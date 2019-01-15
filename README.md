
# C# mysql connection over ssh

## What's this?

It's a proof of concept C# application that connects to a remote MySQL database over a port forwarded SSH connection.

It uses the mysql employee example database.

## How does it work?
- It starts up and makes an ssh connection with a port forward to the DB.
- kicks off the main application window.
- makes a MySQL connection over the SSH port forward
- creates a MySqlDataAdapter with a simple query
- Connects a DataGridView through a MySqlDataAdapter

## How to run this

### Machines
You need a linux box, or virtual linux box to run this, plus your development machine.

### Mysql setup

#### The easy way
The easiest way is to use docker to setup a running mysql DB with the mysql example employee database 

On your remote system install docker, then pull the required mysql server docker file.

```bash
docker pull genschsa/mysql-employee
```

Now run the server.

```bash
docker run -d   --name mysql-employees   -p 53306:3306   -e MYSQL_ROOT_PASSWORD=college   -v $PWD/data:/var/lib/mysql   genschsa/mysql-employees
```

***Note: we are using port 53306 not to conflict with any other running mysql instances ***

#### The Manual way
Add the mysql employees sample data to your system, and add a user to access it.

### Server user setup
Add a user to your system that we can access over ssh

```bash
useradd -m CSAppWithSshDB
```

Set the users password.
```bash
passwd CSAppWithSshDB
```
You can set the password to whatever you like, but by default the code is expecting you to use "how23do44ssh67blanket"

### Changing credentials in the code
MySQL credentials are stored in the comms.db.MysqlConnectionParams class.
SSH connection credentials are stored in the comms.ssh.SshConnParams class.

## License
This example code is licensed under the MIT License.  
