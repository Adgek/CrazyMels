﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrazyMelService
{
    public class Validator
    {
    	public Validator()
    	{

    	}

    	public static bool ValidateVarChar(string input, int size)
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
    	public static  bool ValidateInt(string input)
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
    	public static  bool ValidateFloat(string input)
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
	}
    }
}