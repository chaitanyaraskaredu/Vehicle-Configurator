package com.vita.model;

import java.util.Random;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.PrePersist;

@Entity
public class User {

	@Id
	private String userid;
	private String address_line1;
	private String address_line2;
	private String city;
	private String company_name;
	
	@Column(nullable = false, unique = true) //if 2 users have same email will give error 
	private String email;
	private String gst_number;
	private String password;
	private String pin_code;
	private String state;
	private String telephone;
	private String username;

	public User() {
	}

	public User(String userid, String address_line1, String address_line2, String city, String company_name,
			String email, String gst_number, String password, String pin_code, String state, String telephone,
			String username) {
		this.userid = userid;
		this.address_line1 = address_line1;
		this.address_line2 = address_line2;
		this.city = city;
		this.company_name = company_name;
		this.email = email;
		this.gst_number = gst_number;
		this.password = password;
		this.pin_code = pin_code;
		this.state = state;
		this.telephone = telephone;
		this.username = username;
	}

	@PrePersist
	public void generateCustomerId() {
		if (this.userid == null) {
			String characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			StringBuilder sb = new StringBuilder(6);
			Random random = new Random();
			for (int i = 0; i < 6; i++) {
				sb.append(characters.charAt(random.nextInt(characters.length())));
			}
			this.userid = sb.toString();
		}
	}

	public String getUserid() {
		return userid;
	}

	public void setUserid(String userid) {
		String characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		StringBuilder sb = new StringBuilder(6);
		Random random = new Random();
		for (int i = 0; i < 6; i++) {
			sb.append(characters.charAt(random.nextInt(characters.length())));
		}
		// Convert StringBuilder to String
		userid = sb.toString();
		// Assign to the field
		this.userid = userid;
	}

	@Column(nullable = false)
	public String getAddress_line1() {
		return address_line1;
	}

	public void setAddress_line1(String address_line1) {
		this.address_line1 = address_line1;
	}

	public String getAddress_line2() {
		return address_line2;
	}

	public void setAddress_line2(String address_line2) {
		this.address_line2 = address_line2;
	}

	@Column(nullable = false)
	public String getCity() {
		return city;
	}

	public void setCity(String city) {
		this.city = city;
	}

	@Column(nullable = false)
	public String getCompany_name() {
		return company_name;
	}

	public void setCompany_name(String company_name) {
		this.company_name = company_name;
	}

	@Column(nullable = false)
	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	@Column(nullable = false)
	public String getGst_number() {
		return gst_number;
	}

	public void setGst_number(String gst_number) {
		this.gst_number = gst_number;
	}

	@Column(nullable = false)
	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	@Column(nullable = false)
	public String getPin_code() {
		return pin_code;
	}

	public void setPin_code(String pin_code) {
		this.pin_code = pin_code;
	}

	@Column(nullable = false)
	public String getState() {
		return state;
	}

	public void setState(String state) {
		this.state = state;
	}

	@Column(nullable = false)
	public String getTelephone() {
		return telephone;
	}

	public void setTelephone(String telephone) {
		this.telephone = telephone;
	}

	@Column(unique = true, nullable = false)
	public String getUsername() {
		return username;
	}

	public void setUsername(String username) {
		this.username = username;
	}

	@Override
	public String toString() {
		return "User [userid=" + userid + ", address_line1=" + address_line1 + ", address_line2=" + address_line2
				+ ", city=" + city + ", company_name=" + company_name + ", email=" + email + ", gst_number="
				+ gst_number + ", password=" + password + ", pin_code=" + pin_code + ", state=" + state + ", telephone="
				+ telephone + ", username=" + username + "]";
	}
}
