drop table carinform
/
drop table userinform
/
drop table paying
/
drop table enroll
/
drop table register
/
create table userinform(u_id varchar(20) primary key,u_passwd varchar(20), u_name varchar(20), u_phone varchar(20), u_email varchar(20)) 
/
create table carinform(c_id varchar(20), c_kind varchar(20), c_name varchar(20), c_size varchar(20), u_id varchar(20), primary key(c_id,u_id), foreign key(u_id) references userinform(u_id))
/
create table enroll(s_code varchar(20) primary key,u_id varchar(20),inTime varchar(20))
/
create table register(r_code varchar(20) primary key,r_name varchar(20),r_phone varchar(20),r_email varchar(20),r_notice varchar(300))
/
create table paying(p_code varchar(20),u_id varchar(20),sum number,s_code varchar(20),inTime varchar(20),outTime varchar(20),r_code varchar(20),primary key(p_code,r_code),foreign key(r_code) references register(r_code))
/
insert into userinform values('qkrrlfehd', '123', '박길동', '010-222-2222' ,'222@bc.ac.kr')
/
insert into userinform values('dlrlfehd', '123', '이길동', '010-333-3333', '333@bc.ac.kr')
/
insert into userinform values('ghdrlfehd', '123', '홍길동', '010-333-3333', '333@bc.ac.kr')
/
insert into carinform values('가12나다', '벤츠', 'AMG-GT-43', '경차', 'qkrrlfehd') 
/
insert into carinform values('가12수다','벤츠','C200 4MATIC','대형','dlrlfehd')
/
insert into carinform values('가12다다','BMW','M340i x드라이브','소형','ghdrlfehd')
/
insert into enroll values('A1',null,null)
/
insert into enroll values('A2',null,null)
/
insert into enroll values('A3',null,null)
/
insert into enroll values('A4',null,null)
/
insert into enroll values('A5',null,null)
/
insert into enroll values('A6',null,null)
/
insert into enroll values('A7',null,null)
/
insert into enroll values('A8',null,null)
/
insert into enroll values('A9',null,null)
/
insert into enroll values('A10',null,null)
/
insert into enroll values('A11',null,null)
/
insert into enroll values('A12',null,null)
/
insert into enroll values('A13',null,null)
/
insert into enroll values('A14',null,null)
/
insert into enroll values('A15',null,null)
/
insert into enroll values('A16',null,null)
/
insert into enroll values('A17',null,null)
/
insert into enroll values('A18',null,null)
/
insert into enroll values('A19',null,null)
/
insert into enroll values('A20',null,null)
/
insert into enroll values('A21',null,null)
/
insert into enroll values('A22',null,null)
/
insert into enroll values('A23',null,null)
/
insert into enroll values('A24',null,null)
/
insert into enroll values('A25',null,null)
/
insert into enroll values('A26',null,null)
/
insert into register values(1,'유정호','010-3551-4848','register@gmail.com','관리자 유정호 입니다 안녕하세요')
/
