# Password-Manager
**Password Manager** - *is an application that allows you to effectively manage your passwords.*

## Description
*This application is designed to allow users to securely and conveniently store their passwords. It provides the ability to create secure passwords, store them in a secure vault and access them using a master password.*

## Main features
 + **Secure password storage**: *All passwords are stored in secure, encrypted storage for privacy.*
 + **Create secure passwords**: *The program allows you to generate random and complex passwords for each account.*
 + **Importing/Exporting passwords**: *The program provides the ability to import and export passwords for easy movement between different devices or services.*
 + **Validator**: *Built-in validator allows you to evaluate the reliability of your password by analyzing its complexity and length to ensure the maximum level of security of your account.*
 + **Categories**: *The user can create categories and group their passwords for better management.*


## How to start?
 1. **Fork the Repository:** Click the "*Fork*" button in the upper right corner of the repository page on GitHub. This will create a copy of the repository in your own *GitHub* account.
 2. **Clone Your Fork:** Go to your new *Fork repository* in your *GitHub* account. Click the "*Code*" button, then *copy the link*. In your *terminal* on your computer, type ***git clone followed by the link to your Fork to clone it to your computer***.

## For Pull-Request Authors
 1. **Fork the Repository:** Start by forking the repository you want to contribute to. This creates a copy of the repository in your own GitHub account.

 2. **Clone Your Fork:*** Clone your forked repository to your local machine using Git. This allows you to make changes locally.

 3. **Create a Branch:** Create a new branch for your changes. This keeps your main branch clean and allows you to work on specific features or fixes without affecting the main codebase.

 4. **Make Changes:** Make the necessary changes to the codebase. Ensure that your changes are consistent with the project's guidelines and contribute positively to the project.

 5. **Commit Changes:** Once you've made your changes, commit them to your branch with clear and descriptive commit messages. This helps reviewers understand the purpose of each change.

 6. **Push Changes:** Push your changes to your forked repository on GitHub. This updates your branch with the latest changes.

 7. **Create Pull Request:** Go to the original repository on GitHub and create a pull request. Provide a clear title and description for your pull request, explaining what changes you've made and why they're necessary.

### Features of the complexity of the program
*In this program, we adhere to the MVVM pattern, which facilitates the clear separation of responsibilities among different components.*

**Model:** Represents data objects or business logic, keeping them decoupled from the user interface.

**View:** Displays data to the user in a visually appealing format.

**ViewModel:** Acts as an intermediary between the Model and the View. It prepares data from the Model for display in the View and handles user interaction.

**When adding new Views and ViewModels, we follow a structured approach. The path to these components should differ only in the View/ViewModel part. For example, a ViewModel could be located at *MVVM\ViewModel\DemoFolder\DemoViewModel.cs*, while its corresponding View might be at *MVVM\View\DemoFolder\DemoView.xaml*.**

*ViewModels* must inherit from *[ObservableObject](https://github.com/VitaliiTushak/PasswordManager/blob/main/PasswordManager/PasswordManagerWPF/Core/ObservableObject.cs)*, ensuring that *changes in the ViewModel automatically reflect in the View*. Additionally, each *command in a ViewModel* should *implement the [ICommand](https://github.com/VitaliiTushak/PasswordManager/blob/c517bf864454dd5adf3d7de78b9bbebc04777aea/PasswordManager/PasswordManagerWPF/MVVM/ViewModel/Auth/LoginViewModel.cs#L44) interface*. To *initialize a command*, you should *create a new instance of [RelayCommand](https://github.com/VitaliiTushak/PasswordManager/blob/main/PasswordManager/PasswordManagerWPF/Core/RelayCommand.cs)* in the ViewModel's constructor, *passing the method to be executed when the command is invoked as a parameter*.

**If you encounter difficulties understanding this pattern, feel free to reach out to us for assistance. The code itself is straightforward and devoid of complex elements.**

**For any other changes, such as adding a service or utility class, corresponding folders exist to maintain organizational clarity.**

### What do We want to recieve?
 + *We want to get a Pull-Request that clearly sets the goal for execution.*
 + *A clear description of all the changes made by each commit.*
 + *We also want to get an opinion on the benefits provided by this Pull-Request*

## Programing Principles
 + **DRY (Don't Repeat Yourself)**
   - This principle states that every piece of knowledge in a program should have a single, unambiguous representation. Avoid duplicating code, as it increases the risk of errors and complicates maintenance.
   - **Where did we use it?** *According to the MVVM pattern, we strived to adhere to the DRY principle in all aspects of the program. Each ViewModel and View were created with minimal code duplication, and common elements of functionality were extracted into separate services or helper classes to avoid repeating logic.*

 + **KISS (Keep It Simple, Stupid)**
   - The KISS principle advocates for keeping systems as simple as possible, without unnecessary complexity. Simpler solutions are often more effective and easier to understand, test, and maintain.
   - **Where did we use it?** *This principle was applied throughout the project, as it was guided by the architecture and understanding that the code needed to be comprehensible. We aimed to keep each component and functionality as straightforward and clear as possible, avoiding unnecessary complexity and overengineering.*

 + **YAGNI (You Ain't Gonna Need It)**
   - This principle emphasizes the importance of avoiding adding functionality that is not currently needed. Do not implement functionality that is not confirmed by current requirements.
   - **Where did we use it?** *We strictly adhered to this principle throughout the development process. Only the features and functionalities required by the current project requirements were implemented. We refrained from adding any unnecessary or speculative features, ensuring that the codebase remained lean, focused, and aligned with the immediate needs of the project.*

 + **Single Responsibility**
   - A class or module should have only one reason to change. This means that each class or module should perform only one task or be responsible for one aspect of the system.
   - **Where did we use it?** *We ensured adherence to the Single Responsibility Principle throughout the project. Each class was designed to have a clear and specific purpose, focusing on a single responsibility within the system. This approach facilitated better code organization, maintainability, and understanding, as each class had a well-defined scope and purpose, making it easier to modify and extend when necessary.*

 + **Open/Closed**
   - Entities should be open for extension but closed for modification. This means that code should be easily extensible by adding new functionality without modifying existing code.
   - **Where did we use it?** *We adhered to the Open/Closed Principle by designing our classes and modules in a way that allows for extension without requiring modification of existing code. Through the use of abstraction, inheritance, and interfaces, we ensured that new functionality could be added by creating new classes or implementing new interfaces, rather than altering the existing codebase. This approach promotes code stability and reusability, as existing components remain unchanged while new features can be seamlessly integrated.*

 + **Interface Segregation Principle**
   - Clients should not be forced to depend on interfaces they do not use. This means that interfaces should be small and specific to the needs of clients, avoiding the creation of large general interfaces.
   - **Where did we use it?** *We applied the Interface Segregation Principle by designing interfaces that are tailored to the specific requirements of clients, ensuring that each interface contains only the methods relevant to its intended use. By avoiding bloated interfaces with unnecessary methods, we prevented clients from being burdened with dependencies on functionality they do not require. This approach enhances code clarity, simplifies maintenance, and facilitates the development of loosely coupled systems where components can evolve independently.*

 + **Dependency Inversion Principle**
   - High-level modules should not depend on low-level modules. Both types of modules should depend on abstractions. This means that classes should depend on abstractions, not on concrete implementations.
   - **Where did we use it?** *We applied the Dependency Inversion Principle throughout the application by designing classes and modules that depend on abstractions rather than concrete implementations. This promotes flexibility, extensibility, and testability by decoupling components and allowing them to interact through interfaces or abstract classes. By adhering to this principle, we enable easier substitution of components, facilitate the introduction of new features, and reduce the impact of changes in one part of the system on other parts.*


## Design Patterns

 + **Factory Method**
    - Factory Method is a creational design pattern that provides an interface for creating objects in a superclass, but allows subclasses to alter the type of objects that will be created. It encapsulates object creation logic in a method, promoting loose coupling between client code and the created objects.
    - **Where did we use it?** *Ми використовували фабричний метод для створення стратегій та репозиторіїв у нашій програмі. Це дозволило нам динамічно вибирати потрібну стратегію або репозиторій в залежності від конкретного контексту або вхідних даних. Наприклад, для вибору алгоритму генерації паролів або обрання типу репозиторію (наприклад, для користувачів, категорій або паролів) ми використовували фабричний метод. Цей підхід допоміг нам зробити програму більш гнучкою, розширюваною та зручною в обслуговуванні.*

 + **Singleton**
    - Singleton is a creational design pattern that ensures a class has only one instance and provides a global point of access to that instance. It's often used for managing global state or resources that should be shared across the entire application.
    - **Where did we use it?** *This pattern was used to obtain a single instance of the [RepositoryFactory](https://github.com/VitaliiTushak/PasswordManager/tree/main/PasswordManager/PasswordManagerWPF/Repositories/RepositoryFactory) object and all the [repositories](https://github.com/VitaliiTushak/PasswordManager/tree/main/PasswordManager/PasswordManagerWPF/Repositories) it created. This ensured having a single instance of each repository for interaction with the database. Additionally, this pattern provided a convenient mechanism for working with repositories and ensured their interchangeability, thus enhancing code extensibility and maintainability.*
    
 + **Command**
    - Command is a behavioral design pattern that encapsulates a request as an object, thereby allowing for parameterization of clients with queues, requests, and operations. It decouples the sender of a request from its receiver, providing a way to parameterize clients with queues, requests, and operations.
    - **Where did we use it?** *We utilized the Command pattern to implement operations such as adding, editing, and deleting categories and passwords. Each of these operations was encapsulated in a separate command object, enabling effective management of their execution and simplifying the extension of functionality. All commands were organized into separate [folder](https://github.com/VitaliiTushak/PasswordManager/tree/main/PasswordManager/PasswordManagerWPF/Commands), facilitating better code organization and maintenance.*
    
 + **Strategy**
    - Strategy is a behavioral design pattern that defines a family of algorithms, encapsulates each algorithm, and makes them interchangeable. It allows the algorithm to vary independently from clients that use it, promoting flexibility and enabling runtime selection of algorithms.
    - **Where did we use it?** *The Strategy pattern played a pivotal role in two distinct scenarios within our application. Firstly, it was employed in the password generation feature, where multiple variations of password generation algorithms were available. This allowed for flexibility in [generating passwords](https://github.com/VitaliiTushak/PasswordManager/tree/main/PasswordManager/PasswordManagerWPF/MVVM/ViewModel/Menu/GenerationMethods) tailored to different requirements or security levels. Secondly, the Strategy pattern was utilized in implementing the [import/export](https://github.com/VitaliiTushak/PasswordManager/tree/main/PasswordManager/PasswordManagerWPF/MVVM/ViewModel/Menu/ImportAndExport) functionality for passwords. By employing this pattern, we ensured that the application could support various methods of importing and exporting passwords, thus enhancing its versatility and compatibility with different systems or formats.*
    
 + **Chain of Responsibility**
    - Chain of Responsibility is a behavioral design pattern that allows an object to pass a request along a chain of potential handlers until one of them handles the request. It decouples senders and receivers of a request, providing a way to process requests dynamically and handle them at runtime.
    - **Where did we use it?** *This pattern was adopted primarily to streamline the process of password validation, making it more manageable and convenient. Its implementation was particularly instrumental in creating a [validator](https://github.com/VitaliiTushak/PasswordManager/tree/main/PasswordManager/PasswordManagerWPF/MVVM/ViewModel/Menu/Validator) tasked with assessing the reliability of user passwords. By leveraging this pattern, we were able to ensure that the validation process was robust, efficient, and seamlessly integrated into the broader system architecture.*
    
 + **Decorator**
    - Decorator is a structural design pattern that allows behavior to be added to individual objects dynamically, without affecting the behavior of other objects from the same class. It's useful for extending the functionality of classes without subclassing and promoting flexible design.
    - **Where did we use it?** *The decorator was created with the capability of adding new functionality in the form of password encryption/decryption for storing/retrieving from the database. Its implementation can be seen [here](https://github.com/VitaliiTushak/PasswordManager/tree/main/PasswordManager/PasswordManagerWPF/Repositories/Decorator). As for its usage, it was employed in various parts of the codebase where password handling occurs.*
    
*In conclusion, design patterns provide proven solutions to common design problems, promoting code reuse, maintainability, and flexibility. By understanding and applying these patterns appropriately, developers can create more modular, extensible, and maintainable software systems.*


## Refactoring Techniques

 + **Extract Method**

   In our codebase, we often encountered long blocks of code performing a specific sequence of operations. By extracting these code blocks into separate methods, we made the code more readable and easier to understand. For example, the authentication process before accessing passwords was extracted into its own method.

 + **Inline Temp**

   While reviewing the code, we noticed that some temporary variables were used only once to compute a specific expression. Instead, we directly used this expression, which simplified the logic of the method and reduced the number of unnecessary variables.

 + **Rename Method**

   Some methods had implicit or incomplete names, making them harder to understand. We renamed them to more accurately reflect their functionality and intent, improving communication within the team and making the code more understandable for future developers.

 + **Hide Method** 
 Certain methods were intended for internal use only and should not have been accessible from outside the class. We made them private or protected to ensure better encapsulation and prevent unauthorized usage.

 + **Pull Up Field** 
 While working with multiple subclasses, we noticed that they shared common fields such as services or utils. Instead of copying these fields into each subclass, we pulled them up to the superclass to provide a single source of truth and reduce code duplication.

*Throughout the development process, we endeavored to adhere to these refactoring techniques wherever applicable. By applying these techniques, we aimed to improve the overall quality, maintainability, and readability of our codebase.*