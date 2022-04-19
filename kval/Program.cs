
using System;

class Application
{
    public static void Main(String[] args)
    {
        Money dollar = new Money(1, Currency.USD);
        Money euro = new Money(2, Currency.EUR);
        Money rub = new Money(70, Currency.RUB);
        Money rub1 = new Money(80, Currency.RUB);

        Calculator calculator = new Calculator();

        Console.WriteLine(calculator.calcSumToRub(rub, rub1).getAmount());
        Console.WriteLine(calculator.calcDiffToRub(dollar, rub1).getAmount());
        Console.WriteLine(calculator.calcSumToEur(dollar, euro).getAmount());
        Console.WriteLine(calculator.calcDiffToEur(euro, dollar).getAmount());
    }
}

enum Currency
{
    RUB,
    EUR,
    USD
}
class Money
{
    private Currency type;
    private double amount;
    private static double rubToUsd = 80;
    private static double rubToEur = 90;

    public Money(double amount, Currency type)
    {
        this.amount = amount;
        this.type = type;
    }
    public Currency getType()
    {
        return type;
    }
    public void setType(Currency value)
    {
        this.type = value;
    }
    public void setAmount(double value)
    {
        this.amount = value;
    }
    public double getAmount()
    {
        return this.amount;
    }
    public static double getRubToUsd()
    {
        return rubToUsd;
    }
    public static double getRubToEur()
    {
        return rubToEur;
    }


}
class Calculator
{
    public static Money convertToRub(Money money1)
    {
        if (money1.getType() != Currency.RUB)
        {
            if (money1.getType() == Currency.EUR)
            {
                money1.setAmount(money1.getAmount() * Money.getRubToEur());
            }
            if (money1.getType() == Currency.USD)
            {
                money1.setAmount(money1.getAmount() * Money.getRubToUsd());
            }
        }
        money1.setType(Currency.RUB);
        return money1;

    }
    public static Money convertToUsd(Money money1)
    {
        if (money1.getType() != Currency.USD)
        {
            if (money1.getType() == Currency.EUR)
            {
                money1.setAmount(money1.getAmount() * Money.getRubToEur() / Money.getRubToUsd());
            }
            if (money1.getType() == Currency.RUB)
            {
                money1.setAmount(money1.getAmount() / Money.getRubToUsd());
            }
        }

        money1.setType(Currency.USD);
        return money1;
    }

    public static double convertToEur(Money money1)
    {
        if (money1.getType() != Currency.EUR)
        {
            if (money1.getType() == Currency.USD)
            {
                money1.setAmount(money1.getAmount() * Money.getRubToUsd() / Money.getRubToEur());
            }
            if (money1.getType() == Currency.RUB)
            {
                money1.setAmount(money1.getAmount() / Money.getRubToEur());
            }
        }
        money1.setType(Currency.EUR);
        return money1.getAmount();
    }
    public Money calcSumToRub(Money money1, Money money2)
    {
        Money result;
        Calculator.convertToRub(money1);
        Calculator.convertToRub(money2);

        result = new Money(money1.getAmount() + money2.getAmount(), Currency.RUB);
        return result;

    }
    public Money calcSumToUsd(Money money1, Money money2)
    {
        Money result;
        Calculator.convertToUsd(money1);
        Calculator.convertToUsd(money2);

        result = new Money(money1.getAmount() + money2.getAmount(), Currency.USD);
        return result;
    }
    public Money calcSumToEur(Money money1, Money money2)
    {
        Money result;
        Calculator.convertToEur(money1);
        Calculator.convertToEur(money2);

        result = result = new Money(money1.getAmount() + money2.getAmount(), Currency.EUR);
        return result;

    }

    public Money calcDiffToRub(Money money1, Money money2)
    {
        Money result;
        Calculator.convertToRub(money1);
        Calculator.convertToRub(money2);

        result = result = new Money(money1.getAmount() - money2.getAmount(), Currency.RUB);
        return result;
    }

    public Money calcDiffToUsd(Money money1, Money money2)
    {
        Money result;
        Calculator.convertToUsd(money1);
        Calculator.convertToUsd(money2);

        result = result = new Money(money1.getAmount() - money2.getAmount(), Currency.USD);
        return result;
    }

    public Money calcDiffToEur(Money money1, Money money2)
    {
        Money result;
        Calculator.convertToEur(money1);
        Calculator.convertToEur(money2);

        result = new Money(money1.getAmount() - money2.getAmount(), Currency.EUR);
        return result;
    }
}