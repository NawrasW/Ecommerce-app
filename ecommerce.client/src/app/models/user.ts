export class User {
  id!: number;
  firstName!: string;
  lastName!: string;
  email!: string;
  password!: string;
  confirmpassword!: string;
  nationalNumber!: string;
  phoneNumber!: string;
  dateOfBirth: string | number | Date | null | undefined;
  address?: string; // User's address
  city?: string; // User's city
  //state?: string; // User's state
  //zipCode?: string; // User's zip code


  constructor() {
    // Initialize dateOfBirth as null or any default value
    this.dateOfBirth = null;
  }
}
