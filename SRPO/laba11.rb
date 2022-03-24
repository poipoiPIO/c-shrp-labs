# Base template for all food
class Food
  attr_reader :name, :cost

  def initialize(name, cost)
    @name, @cost = name, cost
  end
end

# Some type of food with limitations
class Alcohol < Food
end

# The cash-storage of our cafe
class CashBox
  attr_reader :cafe_owner, :cashbox_accessors
  attr_accessor :cash_amount

  def initialize(accessors, cafe_owner, cash_amount = 0)
    @cash_amount, @cafe_owner, @cashbox_accessors =
      cash_amount, cafe_owner, accessors
  end

  def add(cost, performer)
    raise "#{performer.name} doesn't have any rights to perform this operation" unless @cashbox_accessors.include? performer.post

    @cash_amount += cost
    puts "#{cost} was added in the CashBox, balance for now: #{@cash_amount}"
  end

end

# Someone who working in our cafe
class Workman
  attr_reader :name, :post

  def initialize(name, post)
    @name, @post = name, post
  end

  def sell(food, cashbox, customer)
    case food.class.name
    when Alcohol.class.name
      puts "Sorry but we can't sell alchogol for someone who hasn't reached 18 y.o" unless customer.age > 18
      try_sell(food, cashbox, "The alcohol of name #{food.name} was sold by #{food.cost}")
    else
      try_sell(food, cashbox, "The food of #{food.name} was sold by #{food.cost}")
    end
  end

  private

  def try_sell(food, cashbox, success_message)
    begin
      cashbox.add(food.cost, self)
      puts success_message
    rescue
      puts "Sorry, but we can't perform this operation"
    end
  end
end

# Someone who buying food in our cafe
class Customer
  attr_accessor :name, :age

  def initialize(name, age)
    @name, @age = name, age
  end
end

# The owner of cafe
class Owner
  attr_accessor :name

  def initialize(name)
    @name = name
  end

  def take_out_earnings!(cashbox)
    raise "#{@name} doesn't have any rights to perform this operation" unless cashbox.cafe_owner == @name

    cashbox.cash_amount = 0
    puts "#{@name} Taked out all the eqrnings"
  end
end

owner = Owner.new('Victor')
customer1 = Customer.new('Gena', 19)
customer2 = Customer.new('Vitya', 11)
worker1 =  Workman.new('Mina', 'Cashier')
worker2 =  Workman.new('Oliya', 'Bullbuster')
cashbox = CashBox.new(['Cashier', 'Owner'], 'Victor')
worker1.sell(Food.new('Ogirizi', 1200), cashbox, customer1)
worker2.sell(Alcohol.new('Suladosisa', 1200), cashbox, customer2)
owner.take_out_earnings!(cashbox)
