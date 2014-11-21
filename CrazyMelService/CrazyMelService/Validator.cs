using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrazyMelService
{
    public static class Validator
    {
    	public static bool ValidateVarchar(string input, int size)
    	{
    		if (input.Length > size)
    		{
    			return false;
    		}
    		return true;
    	}

    	public static bool ValidateBool(string input)
    	{
    		try
    		{
    			Convert.ToBoolean(input);
    		}
    		catch(Exception e)
    		{
    			return false;
    		}
    		return true;
    	}

    	public static bool ValidateInt(string input)
    	{
    		try
    		{
    			Convert.ToInt32(input);
    		}
    		catch(Exception e)
    		{
    			return false;
    		}
    		return true;
    	}

    	public static bool ValidateFloat(string input)
    	{
    		try
    		{
    			Convert.ToSingle(input);
    		}
    		catch(Exception e)
    		{
    			return false;
    		}
    		return true;
    	}

    	public static bool ValidateDate(string input)
		{
			DateTime testDateTimeValue;
			if(!DateTime.TryParse(input, out testDateTimeValue))
			{
				return false;
			}
			return true;
		}
	}    
}